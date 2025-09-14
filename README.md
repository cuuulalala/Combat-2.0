# Combat-2.0

## Quick Scene Setup (≈10 minutes)

1. **Create Scene**
   - Start a new 2D scene and save it.
codex/implement-player-movement-and-shooting-mechanics-c0ewn5
   - A yellow circular sprite is auto‑generated on startup, along with `Rigidbody2D`, collider, and tag `Player`.
   - Attach `PlayerController2D`, `Weapon` and `Health` components.
   - Create an empty child called `FirePoint` at the muzzle and assign it along with a bullet prefab to `Weapon`.
   - **Input System**: this controller reads from the new Input System. Ensure the project is configured for the *Input System Package* or "Both" in `Edit → Project Settings → Player → Active Input Handling`.

   - Add a sprite with `Rigidbody2D` and a collider.
   - Tag it as `Player` and attach `PlayerController2D`, `Weapon` and `Health`.
   - Create an empty child called `FirePoint` at the muzzle and assign it along with a bullet prefab to `Weapon`.
 main
3. **Bullet Prefab**
   - Create a new prefab with a sprite, `Rigidbody2D` (kinematic) and a trigger collider.
 codex/implement-player-movement-and-shooting-mechanics-c0ewn5
   - Add a red circular sprite with `Rigidbody2D` and a collider.
main
   - Attach `EnemyAI` and `Health`.
5. **Game Manager**
 codex/implement-player-movement-and-shooting-mechanics-c0ewn5
   - Press Play: the green grid marks the environment, the yellow player rotates to the mouse, and red enemies chase you. Use WASD to move and left mouse button to shoot.
   - If sprites render dark or show blue/black artifacts, assign the `Sprite Unlit` material or add a `Global Light 2D` when using URP.

   - Press Play and use WASD to move, left mouse button to shoot, and survive.
main

These scripts and prefabs provide a minimal top‑down combat prototype.
