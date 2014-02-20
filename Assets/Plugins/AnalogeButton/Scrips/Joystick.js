//////////////////////////////////////////////////////////////
// Joystick.js
// Penelope iPhone Tutorial
//
// Joystick creates a movable joystick (via GUITexture) that 
// handles touch input, taps, and phases. Dead zones can control
// where the joystick input gets picked up and can be normalized.
//////////////////////////////////////////////////////////////

@script RequireComponent( GUITexture )

// A simple class for bounding how far the GUITexture will move
class Boundary 
{
	var min : Vector2 = Vector2.zero;
	var max : Vector2 = Vector2.zero;
}

static private var joysticks : Joystick[];					// A static collection of all joysticks
static private var enumeratedJoysticks : boolean = false;
static private var tapTimeDelta : float = 0.3;				// Time allowed between taps

public var position : Vector2; 								// [-1, 1] in x,y
public var deadZone : Vector2 = Vector2.zero;				// Control when position is output
public var normalize : boolean = false; 					// Normalize output after the dead-zone?
public var tapCount : int;									// Current tap count

private var lastFingerId = -1;								// Finger last used for this joystick
private var tapTimeWindow : float;							// How much time there is left for a tap to occur
private var gui : GUITexture;								// Joystick graphic
private var defaultRect : Rect;								// Default position / extents of the joystick graphic
private var guiBoundary : Boundary = Boundary();			// Boundary for joystick graphic
private var guiTouchOffset : Vector2;						// Offset to apply to touch input
private var guiCenter : Vector2;							// Center of joystick graphic

function Start()
{
	// Cache this component at startup instead of looking up every frame	
	gui = GetComponent( GUITexture );
	
	// Store the default rect for the gui, so we can snap back to it
	defaultRect = gui.pixelInset;
	
	// This is an offset for touch input to match with the top left
	// corner of the GUI
	guiTouchOffset.x = defaultRect.width * 0.5;
	guiTouchOffset.y = defaultRect.height * 0.5;
	
	// Cache the center of the GUI, since it doesn't change
	guiCenter.x = defaultRect.x + guiTouchOffset.x;
	guiCenter.y = defaultRect.y + guiTouchOffset.y;
	
	// Let's build the GUI boundary, so we can clamp joystick movement
	guiBoundary.min.x = defaultRect.x - guiTouchOffset.x;
	guiBoundary.max.x = defaultRect.x + guiTouchOffset.x;
	guiBoundary.min.y = defaultRect.y - guiTouchOffset.y;
	guiBoundary.max.y = defaultRect.y + guiTouchOffset.y;
}

function Disable()
{
	gameObject.active = false;
	enumeratedJoysticks = false;
}

function Reset()
{
	// Release the finger control and set the joystick back to the default position
	gui.pixelInset = defaultRect;
	lastFingerId = -1;
}
	
function LatchedFinger( fingerId : int )
{
	// If another joystick has latched this finger, then we must release it
	if ( lastFingerId == fingerId )
		Reset();
}

function Update()
{	
	if ( !enumeratedJoysticks )
	{
		// Collect all joysticks in the game, so we can relay finger latching messages
		joysticks = FindObjectsOfType( Joystick );
		enumeratedJoysticks = true;
	}	
		
	var count = Input.touchCount;
	
	// Adjust the tap time window while it still available
	if ( tapTimeWindow > 0 )
		tapTimeWindow -= Time.deltaTime;
	else
		tapCount = 0;
	
	if ( count == 0 )
		Reset();
	else
	{
		for(var i : int = 0;i < count; i++)
		{
			var touch : Touch = Input.GetTouch(i);			
			var guiTouchPos : Vector2 = touch.position - guiTouchOffset;
	
			// Latch the finger if this is a new touch
			if ( gui.HitTest( touch.position ) && ( lastFingerId == -1 || lastFingerId != touch.fingerId ) )
			{
				lastFingerId = touch.fingerId;
				
				// Accumulate taps if it is within the time window
				if ( tapTimeWindow > 0 )
					tapCount++;
				else
				{
					tapCount = 1;
					tapTimeWindow = tapTimeDelta;
				}
											
				// Tell other joysticks we've latched this finger
				for ( var j : Joystick in joysticks )
				{
					if ( j != this )
						j.LatchedFinger( touch.fingerId );
				}						
			}				
	
			if ( lastFingerId == touch.fingerId )
			{	
				// Override the tap count with what the iPhone SDK reports if it is greater
				// This is a workaround, since the iPhone SDK does not currently track taps
				// for multiple touches
				if ( touch.tapCount > tapCount )
					tapCount = touch.tapCount;
					
				// Change the location of the joystick graphic to match where the touch is
				gui.pixelInset.x = Mathf.Clamp( guiTouchPos.x, guiBoundary.min.x, guiBoundary.max.x );
				gui.pixelInset.y = Mathf.Clamp( guiTouchPos.y, guiBoundary.min.y, guiBoundary.max.y );		
				
				if ( touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled )
					Reset();					
			}			
		}
	}
	
	// Get a value between -1 and 1
	position.x = ( gui.pixelInset.x + guiTouchOffset.x - guiCenter.x ) / guiTouchOffset.x;
	position.y = ( gui.pixelInset.y + guiTouchOffset.y - guiCenter.y ) / guiTouchOffset.y;
	
	// Adjust for dead zone	
	var absoluteX = Mathf.Abs( position.x );
	var absoluteY = Mathf.Abs( position.y );
	
	if ( absoluteX < deadZone.x )
	{
		// Report the joystick as being at the center if it is within the dead zone
		position.x = 0;
	}
	else if ( normalize )
	{
		// Rescale the output after taking the dead zone into account
		position.x = Mathf.Sign( position.x ) * ( absoluteX - deadZone.x ) / ( 1 - deadZone.x );
	}
		
	if ( absoluteY < deadZone.y )
	{
		// Report the joystick as being at the center if it is within the dead zone
		position.y = 0;
	}
	else if ( normalize )
	{
		// Rescale the output after taking the dead zone into account
		position.y = Mathf.Sign( position.y ) * ( absoluteY - deadZone.y ) / ( 1 - deadZone.y );
	}
}