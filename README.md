# Pokémon AR - Ataque Relámpago

Experiencia de realidad aumentada hecha en Unity que usa **Vuforia Engine**
para reconocer dos cartas físicas de Pokémon (Pikachu y Charizard) a través
de la cámara y disparar una animación de ataque entre ambos modelos 3D.

## 🎮 Cómo funciona

1. La cámara reconoce cada carta como una imagen de referencia (Image Target).
2. Sobre cada carta aparece su modelo 3D correspondiente, con su animación
   idle.
3. Al acercar las cartas entre sí, un Collider detecta el "choque":
   - Pikachu reproduce su animación de salto/baile.
   - Se dispara un rayo (Lightning Bolt) desde Pikachu hacia Charizard.

## 🛠️ Tecnologías

- **Unity 6** (6000.6.0f1)
- **Vuforia Engine** — reconocimiento de imágenes vía webcam, sin necesidad
  de build a dispositivo móvil
- **Digital Ruby's Lightning Bolt Effect** — efecto visual del rayo
- C# / MonoBehaviour para la lógica de interacción

## ▶️ Cómo probarlo

1. Abrir el proyecto en Unity.
2. Entrar en modo Play (usa la webcam).
3. Mostrar las cartas impresas de Pikachu y Charizard frente a la cámara.
4. Acercar ambas cartas para activar la animación y el ataque.

## 📂 Estructura relevante

- `Assets/OnTriggerInteraction.cs` — controla la animación de Pikachu al
  detectar contacto.
- `Assets/Scripting/RayoPikachu.cs` — controla el disparo del rayo hacia
  Charizard.
- `Assets/Scenes/SampleScene.unity` — escena principal con los Image
  Targets configurados.

## 📝 Notas

Proyecto educativo/de práctica para explorar AR con reconocimiento de
imágenes en Unity sin depender de un build móvil.
