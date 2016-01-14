// -----------------------------------------------------------------------
// <file>MainForm.cs</file>
// <copyright>Grupa za Grafiku, Interakciju i Multimediju 2013.</copyright>
// <author>Zoran Milicevic</author>
// <summary>Demonstracija ucitavanja modela pomocu AssimpNet biblioteke i koriscenja u OpenGL-u.</summary>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Assimp;
using System.IO;
using System.Reflection;

namespace RacunarskaGrafika.Vezbe.AssimpNetSample
{
    public partial class MainForm : Form
    {
        #region Atributi

        /// <summary>
        ///	 Instanca OpenGL "sveta" - klase koja je zaduzena za iscrtavanje koriscenjem OpenGL-a.
        /// </summary>
        World m_world = null;
        private Boolean animationPlaying = false;
        private int animationDuration = 5;

        #endregion Atributi

        #region Konstruktori

        public MainForm()
        {
            // Inicijalizacija komponenti
            InitializeComponent();

            // Inicijalizacija OpenGL konteksta
            openglControl.InitializeContexts();

            // Kreiranje OpenGL sveta
            try
            {
                m_world = new World(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "3D Models\\SpaceShip"), "space-ship.obj", openglControl.Width, openglControl.Height); // "3D Models\\SpaceShip"), "space-ship.obj" "3D Models\\"), "UFO.obj"
            }
            catch (Exception e)
            {
                MessageBox.Show("Neuspesno kreirana instanca OpenGL sveta. Poruka greške: " + e.Message, "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        #endregion Konstruktori

        #region Rukovaoci dogadjajima OpenGL kontrole

        /// <summary>
        /// Rukovalac dogadja izmene dimenzija OpenGL kontrole
        /// </summary>
        private void OpenGlControlResize(object sender, EventArgs e)
        {
            m_world.Height = openglControl.Height;
            m_world.Width = openglControl.Width;

            m_world.Resize();
        }

        /// <summary>
        /// Rukovalac dogadjaja iscrtavanja OpenGL kontrole
        /// </summary>
        private void OpenGlControlPaint(object sender, PaintEventArgs e)
        {
            // Iscrtaj svet
            m_world.Draw();
        }

        /// <summary>
        /// Rukovalac dogadjaja: obrada tastera nad formom
        /// </summary>
        private void OpenGlControlKeyDown(object sender, KeyEventArgs e)
        {if(!animationPlaying)
            switch (e.KeyCode)
            {
                case Keys.F5: this.Close(); break;
                case Keys.T: if (m_world.RotationX > -25) m_world.RotationX -= 5.0f; break;
                case Keys.G: if (m_world.RotationX < 200) m_world.RotationX += 5.0f; break;
                case Keys.F: m_world.RotationY -= 5.0f; break;
                case Keys.H: m_world.RotationY += 5.0f; break;
                case Keys.Add:  m_world.SceneDistance -= 5.0f; m_world.Resize(); break;
                case Keys.Subtract: m_world.SceneDistance += 5.0f; m_world.Resize(); break;
             
                case Keys.S: animationPlaying = true;

                   
                    domainUpDownHeight.Enabled = false;
                    domainUpDownRotation.Enabled = false;
                    domainUpDownScaleX.Enabled = false;
                    domainUpDownScaleZ.Enabled = false;

                    m_world.RotationAngle = m_world.RotationSpeed;
                    m_world.ShipR = 0.0f;
                    m_world.ShipDistance = 0.0f;

                    animationDuration = 100;
                    timerAnimation.Enabled = true;
                    break;
            }

            openglControl.Refresh();
        }

        #endregion Rukovaoci dogadjajima OpenGL kontrole

        private void timerRotaion_Tick(object sender, EventArgs e)
        {
            m_world.RotateStand();
            m_world.RotateMoon();
            openglControl.Refresh();
        }
        private void timerAnimation_Tick(object sender, EventArgs e)
        {
             animationDuration -= 1;

             if (animationDuration <= 1)
             {
                 animationPlaying = false;

                 timerAnimation.Enabled = false;

                 domainUpDownHeight.Enabled = true;
                 domainUpDownRotation.Enabled = true;
                 domainUpDownScaleX.Enabled = true;
                 domainUpDownScaleZ.Enabled = true;
             }
             // Uzletanje
             if (animationDuration > 95)
             {
                 m_world.ShipHeight += 2.5f;
             }
             // Namestanje za orbitu
             if (animationDuration > 90 && animationDuration < 95)
             {
                 m_world.ShipDistance += 20.5f;
             }
             // Spustanje do ekvatora
             if (animationDuration > 85 && animationDuration < 90)
             {
                 m_world.ShipHeight -= 17.5f;
             }
             // Rotacija oko planete
             if (animationDuration > 15 && animationDuration < 85)
             {
                 m_world.RotateShip();
             }
             // Dizanje do orbite
             if (animationDuration > 10 && animationDuration < 15)
             {
                 m_world.ShipHeight += 17.5f;
             }
             // Namestanje za sletanje 
             if (animationDuration > 5 && animationDuration < 10)
             {
                 m_world.ShipDistance -= 20.5f;
             }
             // Sletanje
             else if (animationDuration < 5)
             {
                 m_world.ShipHeight -= 2.5f;
             }
             
            openglControl.Refresh();
        }

        private void domainUpDownHeight_ValueChanged(object sender, EventArgs e)
        {
            m_world.StandCarrier = Convert.ToInt16(domainUpDownHeight.Value);
            m_world.StandHeight = Convert.ToInt16(domainUpDownHeight.Value);
            m_world.ShipHeight = Convert.ToInt16(domainUpDownHeight.Value);
            openglControl.Refresh();
        }

        private void domainUpDownRotation_ValueChanged(object sender, EventArgs e)
        {
            m_world.RotationSpeed = Convert.ToSingle(domainUpDownRotation.Value);
        }

        private void domainUpDownScaleX_ValueChanged(object sender, EventArgs e)
        {
             m_world.BoxScaleX = Convert.ToInt16(domainUpDownScaleX.Value);
             openglControl.Refresh();
        }

        private void domainUpDownScaleZ_ValueChanged(object sender, EventArgs e)
        {
            m_world.BoxScaleZ = Convert.ToInt16(domainUpDownScaleZ.Value);
            openglControl.Refresh();
        }

    }
}
