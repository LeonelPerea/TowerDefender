using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TowerDefender
{
    class Alien
    {
        const int VELOCIDAD_INITIAL_ALIEN = 100;
        const int MOVER_ARRIBA = -1;
        const int MOVER_ABAJO = -1;
        const int MOVER_IZQUIERDA = -1;
        const int MOVER_DERECHA = -1;

        GraphicsDeviceManager graficos;
        SpriteBatch spriteBatch;
        Texture2D imagenAlien;
        Vector2 posicionActual;

        public Vector2 PosicionActual
        {
            get { return posicionActual; }
            set { posicionActual = value; }
        }
        Vector2 velocidad;
        Vector2 dir;
        int velocidadActual;
        int numeroMovimiento;
        Vector2 posicionComparar;
        int vidas;
        bool enMovimiento = false;

        public enum estatus { DoT, AoE, lento, NormalizationForm }
        public enum habilidad { invisible, camuflado, normal }

        public Alien(Vector2 posicionInicial)
        {
            this.posicionActual = posicionInicial;
        }
        public void avanzar(int distancia, direccion direc, GameTime gameTime)
        {
            if (direc == direccion.derecha)
            {
                dir.X = MOVER_DERECHA;
                posicionActual.X += distancia * VELOCIDAD_INITIAL_ALIEN * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (direc == direccion.izquierda)
            {
                dir.X = MOVER_IZQUIERDA;
                posicionActual.X -= distancia * VELOCIDAD_INITIAL_ALIEN * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (direc == direccion.arriba)
            {
                dir.X = MOVER_ARRIBA;
                posicionActual.Y -= distancia * VELOCIDAD_INITIAL_ALIEN * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (direc == direccion.abajo)
            {
                dir.Y = MOVER_ABAJO;
                posicionActual.Y += distancia * VELOCIDAD_INITIAL_ALIEN * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }
        public void LoadContent(ContentManager contentManager, string nombreAlien)
        {
            imagenAlien = contentManager.Load<Texture2D>(nombreAlien);
        }
        public void dibujarAlien(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(imagenAlien, posicionActual, new Rectangle(0, 0, imagenAlien.Width, imagenAlien.Height), Color.White, 0.0f, Vector2.Zero, 1, SpriteEffects.None, 0);
        }
    }
}
