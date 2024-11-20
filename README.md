## Scenes
To view scene, go to assets->scenes and run SampleScene.Unity

When making a new scene, set up following https://developers.meta.com/horizon/documentation/unity/move-eye-tracking/ (set the reference frame to be the transform of the eye game object and the tracking mode to be world space) and add a line renderer and Eye Ray Script component to the eyes.
To create a game object that can interact with the eye gaze, add the Eye Interactable Script component.

## Scripts
Eye Gaze takes the eye pose data and uses it to move the ray object, which represents the gaze. The Eye Gaze script also checks if the ray collides with an object, sets the Interactable Object to be in a hovered state, and sends the collision position to the log.

Eye Interactable changes its behavior (currently, turns into a different color) when a eye gaze hovers on it.
