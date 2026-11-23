# PathOfDeathTD - Tower Defense Prototype

A technical Unity prototype of a Tower Defense game. The core objective of this project was to architect a highly modular system that allows creating new towers without getting tangled up in the codebase.

This prototype enables rapid tower creation using **ScriptableObjects**. The projectile system is completely decoupled, allowing developers to implement custom projectile behaviors independently. While the current scope includes 1 tower and 1 projectile for demonstration purposes, the underlying architecture is built to scale modularly.

> **Scope Note:** Development focused strictly on tower architecture and combat systems. Enemy AI is intentionally kept minimal (health management and linear pathfinding toward a destination) to serve as a testbed for the towers.

[Demo Gameplay](https://github.com/user-attachments/assets/2cacc450-26a2-433c-8348-56fa11ca6ac8)

---

## Systems Architecture & Technical Features

### Decoupling & Polymorphism
The `Tower` class exclusively manages target detection and fire rate (`attackSpeed`), delegating attack execution through the `ITowerAttack` interface. 

By leveraging `abstract` and `virtual` methods in `ProjectileBase`, each derived projectile (such as `FireDragonProj`) defines its own trajectory via `Move()`, while retaining the flexibility to override impact logic (`OnHit()`) when specialized mechanics are needed.

<img width="2752" height="1536" alt="diagram" src="https://github.com/user-attachments/assets/1fceee35-87d4-43cb-8cf0-07084c53c1ea" />


### ScriptableObjects (Data-Driven Design)
<img width="538" height="365" alt="Captura de pantalla 2026-11-23 181103" src="https://github.com/user-attachments/assets/3de8af3e-9fba-4adc-9322-8d8043dbb1f5" />

To streamline balancing and content creation, **ScriptableObjects** (`TowerData`) are used to store core tower attributes. When instantiating a projectile, the system dynamically injects the tower's data and target reference via `Setup()`.

### Performance Optimization
Instead of running physics queries every frame inside `Update()`, target acquisition is throttled using a configurable timer (`searchInterval = 0.1s`) alongside `Physics.OverlapCapsuleNonAlloc`[cite: 1]. This significantly reduces CPU overhead and eliminates memory allocations during combat when multiple towers are active.

<img width="1412" height="532" alt="Captura de pantalla 2026-11-23 183224" src="https://github.com/user-attachments/assets/13d74f73-00a6-47e6-b131-b753a5f28aaf" />

<img width="521" height="239" alt="Captura de pantalla 2026-11-23 181836" src="https://github.com/user-attachments/assets/88130005-e0ec-432c-b800-bf4629bcc13c" />
