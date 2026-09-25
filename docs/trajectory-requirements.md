# Trajectory Preview Requirements

**Tracking:** A2-01 / SCRUM-24  
**Related issue:** [wagyboy/VR-Petanque#5](https://github.com/wagyboy/VR-Petanque/issues/5)  
**Status:** Draft; awaiting human review

## Purpose

Define the expected trajectory preview behavior before any game implementation or
verification work begins. The preview communicates where a thrown petanque boule
is expected to make its first contact with the playing surface. It is not a
prediction of the boule's complete motion after contact or of its final resting
position.

## Player scenario

While holding a boule, the player aims by adjusting the hand/controller pose and
throw direction. The preview updates from the current aiming input and shows the
predicted flight path up to the first point where the boule would contact the
playable ground. The player uses that point to choose aim and release
parameters, then releases the boule.

The preview should:

- follow the current aiming direction and release parameters;
- identify one predicted first ground-contact point when the trajectory
  intersects playable ground;
- remain understandable when the contact surface is horizontal or sloped; and
- avoid implying that the contact point is where the boule will stop.

If no playable ground intersection can be predicted, the preview should indicate
that no landing point is available rather than displaying a stale point. The
specific no-intersection visual is an implementation decision and remains an
open question below.

## Ground-contact definition

The **predicted first ground contact** is the earliest point along the predicted
flight where the boule's collision geometry intersects the configured playable
ground surface. It is the landing point exposed by the preview.

The contact point must be evaluated against the actual ground surface, including
its height and local slope, rather than assuming a constant world-space height.
The displayed point should therefore lie on the surface used for gameplay
collision. “First” means the first qualifying intersection along the flight
path; later bounces, rolls, and contacts are outside this preview's landing-point
definition.

## Surface scenarios

### Flat ground

For a level playable surface, the predicted contact point is where the
trajectory first reaches the surface's collision height. The visual marker and
trajectory endpoint should agree in horizontal position and surface height,
within the tolerance selected by implementation and review.

### Sloped ground

For a continuous slope, the predicted contact point is where the flight path
first intersects the sloped collision surface. Its height must be sampled from
that surface at the contact location; it must not be forced to the height of a
global horizontal plane. The marker should remain attached to the slope and
the preview should not move the point to a later, lower, or higher position
merely because that position is easier to represent.

If terrain contains an obstruction, discontinuity, or multiple candidate
surfaces, the first intersection with an eligible playable-ground collider
wins. The eligibility rules for terrain and other colliders are an open
implementation question.

## First contact versus final resting position

These are separate concepts:

| Concept | Meaning | Included in this requirement |
| --- | --- | --- |
| First ground contact | Earliest collision of the predicted flight with playable ground | Yes; this is the preview landing point |
| Subsequent motion | Bounce, roll, slide, or additional collisions after contact | No; not represented by the landing-point acceptance criteria |
| Final resting position | Position after motion has settled under the physics rules | No; it must not be presented as the first-contact marker |

The preview must not label or describe the first-contact marker as the
boule's final destination. A future feature may predict post-contact motion,
but that would require separate requirements and acceptance criteria.

## Assumptions

- A playable-ground collision surface is available to the trajectory system.
- The trajectory preview uses the same relevant ground geometry as gameplay
  collision, or any difference is explicitly documented and reviewed.
- The player's current aiming pose and release parameters are the inputs to the
  prediction.
- The boule is treated as a collision volume, not only as a point, when
  determining first contact.
- The preview is allowed to update continuously while the player aims.
- “Ground” excludes non-playable scenery unless an implementation explicitly
  marks that scenery as eligible.
- This document defines behavior only; no game behavior is claimed to have
  been implemented or tested by this task.

## Open questions

- What visual marker and wording should communicate first contact without
  implying final resting position?
- What tolerance is acceptable between the rendered endpoint, marker, and
  collision surface?
- Which collider layers/tags identify eligible playable ground?
- How should the preview represent a trajectory with no eligible intersection?
- Should the preview include the boule radius and other collision-shape
  details, and what physics timestep/settings should it use?
- If the surface changes abruptly or multiple eligible colliders overlap, what
  ordering and visual treatment should be used?
- Is post-contact bounce/roll prediction intentionally deferred for the whole
  feature, or planned as a separate follow-up?

## Acceptance criteria

These checkboxes remain unchecked until human review is complete. They are
requirements for review, not evidence that the game behavior has been tested.

- [ ] The player aiming scenario and expected preview response are documented.
- [ ] Predicted landing is defined as the first contact with eligible ground.
- [ ] Flat-ground behavior is specified.
- [ ] Sloped-ground behavior is specified using the actual surface height.
- [ ] First contact is clearly distinguished from final resting position and
      subsequent motion.
- [ ] Assumptions are explicitly listed.
- [ ] Open questions and unresolved implementation decisions are explicitly
      listed.
- [ ] A human review confirms the document satisfies the issue requirements.
- [ ] The pull request is reviewed and merged, and its link is added to the
      issue as completion evidence.

## Review and verification boundary

This deliverable has received only author self-review during drafting. Per
`docs/workflow-policy.md`, self-review is not independent approval. No Unity
scene, executable game behavior, or automated game test was run for this
documentation task; game test cases remain **Not Run** until an implementation
exists.
