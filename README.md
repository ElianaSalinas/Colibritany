# Colibritany AR

Proyecto de realidad aumentada en **Unity 6** con **Vuforia Engine**. La cámara
reconoce imágenes impresas (Image Targets) y muestra contenido 3D o video encima
de ellas en tiempo real.

El proyecto tiene dos experiencias:

1. **Video AR de Colibritany**: al apuntar la cámara a la portada del video
   *"Colibritany – Mi Sexy Chambelán"*, la portada cobra vida y el video se
   reproduce encima de ella.
2. **Pikachu vs. Charizard (Ataque Relámpago)**: dos cartas de Pokémon se
   reconocen por separado, cada una muestra su modelo 3D animado y, al
   acercarlas, Pikachu salta y lanza un rayo contra Charizard.

---

## ✨ Cómo funciona

### Video AR
- La portada del video (`Assets/Resources/descarga.png`) está configurada como
  Image Target.
- `ARCamera` (Vuforia) usa la webcam para buscarla.
- Cuando la detecta, se activa un `Plane` hijo del target con un **Video Player**
  que reproduce el video justo encima de la portada.

### Pikachu vs. Charizard
1. Cada carta (`Assets/ImageTargets/pikachu.jpeg` y `charizard.jpeg`) es un
   Image Target con su modelo 3D y su animación.
2. Al juntar las cartas, los colliders detectan el contacto:
   - `OnTriggerInteraction` activa la animación de salto/baile de Pikachu
     (parámetro `IsInteracting` del Animator).
   - `RayoPikachu` dispara un rayo desde Pikachu hacia Charizard durante un
     tiempo configurable, con enfriamiento entre ataques.

---

## 🛠️ Tecnologías

| Herramienta | Uso |
|---|---|
| Unity **6000.6.0f1** | Motor del proyecto |
| Vuforia Engine **11.4.4** | Reconocimiento de imágenes (incluido en `Packages/`) |
| Lightning Bolt Effect (Digital Ruby) | Efecto visual del rayo |
| C# | Lógica de interacción |

---

## ▶️ Cómo ejecutarlo

1. **Instala Git LFS** antes de clonar (los modelos, imágenes y el video se
   guardan con LFS):
   ```bash
   git lfs install
   git clone https://github.com/ElianaSalinas/Colibritany.git
   ```
2. Abre la carpeta del proyecto en **Unity Hub** con la versión 6000.6.0f1
   (o una 6.x compatible).
3. Abre `Assets/Scenes/SampleScene.unity`.
4. Pulsa **Play**. Vuforia usa la webcam del computador, no hace falta
   compilar para móvil.
5. Muestra la portada del video de Colibritany frente a la cámara (o las cartas de
   Pikachu y Charizard, según la escena que estés usando).

> Si Vuforia pide una *License Key*, crea una gratis en el
> [Vuforia Developer Portal](https://developer.vuforia.com/) y pégala en
> `Assets/Resources/VuforiaConfiguration.asset`.

---

## 📂 Estructura

```
Assets/
├── Scenes/SampleScene.unity      # Escena principal (ARCamera + Image Target + video)
├── Resources/                    # Video de Colibritany, su portada (target) y config de Vuforia
├── ImageTargets/                 # Cartas de Pikachu y Charizard
├── Models/                       # Modelos .glb y Animators de Pikachu y Charizard
├── LightningBolt/                # Asset del efecto de rayo
├── OnTriggerInteraction.cs       # Animación de Pikachu al detectar contacto
└── Scripting/RayoPikachu.cs      # Disparo del rayo hacia Charizard
Packages/
└── com.ptc.vuforia.engine-11.4.4.tgz
```

---

## ⚙️ Configurar el ataque de Pikachu

En el Inspector, dentro del componente **RayoPikachu**:

| Campo | Descripción |
|---|---|
| `Rayo` | Objeto con `LightningBoltScript` |
| `Origen Rayo` | Punto desde donde sale el rayo (ej. cabeza de Pikachu) |
| `Charizard` | Modelo de Charizard con Collider |
| `Punto Impacto` | *(Opcional)* punto donde impacta el rayo |
| `Retraso` / `Duración` / `Intervalo` / `Enfriamiento` | Tiempos del ataque |

---

## 📝 Notas

Proyecto educativo para practicar realidad aumentada con reconocimiento de
imágenes en Unity, sin depender de un build móvil.
