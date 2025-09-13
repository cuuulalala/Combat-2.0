# Combat-2.0

## Quick Scene Setup (≈10 minutes)

1. **Create Scene**
   - Start a new 2D scene and save it.
2. **Player**
   - Add a sprite with `Rigidbody2D` and a collider.
   - Tag it as `Player` and attach `PlayerController2D`, `Weapon` and `Health`.
   - Create an empty child called `FirePoint` at the muzzle and assign it along with a bullet prefab to `Weapon`.
3. **Bullet Prefab**
   - Create a new prefab with a sprite, `Rigidbody2D` (kinematic) and a trigger collider.
   - Attach the `Bullet` script.
4. **Enemy Prefab**
   - Add a sprite with `Rigidbody2D` and a collider.
   - Attach `EnemyAI` and `Health`.
5. **Game Manager**
   - Create an empty object and attach `GameManager`.
   - Provide the enemy prefab and one or more spawn points.
6. **Run**
   - Press Play and use WASD to move, left mouse button to shoot, and survive.

These scripts and prefabs provide a minimal top‑down combat prototype.
