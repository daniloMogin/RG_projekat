// -----------------------------------------------------------------------
// <file>World.cs</file>
// <copyright>Grupa za Grafiku, Interakciju i Multimediju 2013.</copyright>
// <author>Zoran Milicevic</author>
// <summary>Klasa koja enkapsulira OpenGL programski kod.</summary>
// -----------------------------------------------------------------------
namespace RacunarskaGrafika.Vezbe.AssimpNetSample
{
    using System;
    using Tao.OpenGl;
    using Assimp;
    using System.IO;
    using System.Reflection;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    /// <summary>
    ///  Klasa enkapsulira OpenGL kod i omogucava njegovo iscrtavanje i azuriranje.
    /// </summary>
    public class World : IDisposable
    {
        #region Atributi
        private enum TextureObjects { Moon = 0, Metal_dark, Metal_light };
        private readonly int m_textureCount = Enum.GetNames(typeof(TextureObjects)).Length;

        /// <summary>
        ///	 Identifikatori OpenGL tekstura
        /// </summary>
        private int[] m_textures = null;

        /// <summary>
        ///	 Putanje do slika koje se koriste za teksture
        /// </summary>
        private string[] m_textureFiles = { "..//..//images//moon.jpg", "..//..//images//metal_light.jpg", "..//..//images//metal_dark.jpg" };

        /// <summary>
        ///	 Scena koja se prikazuje.
        /// </summary>
        private AssimpScene m_scene;
        private Box postolje;

        private float boxScaleX = 40.0f;
        private float boxScaleZ = 40.0f;
        private float rotationAngle = 180.0f;
        private float rotationSpeed = 2.0f;
        private float standAngle = 0;
        private float standHeight = 0.0f;

        private double scaleShip = 1.0;
        private float shipHeight = 0.0f;
        private float m_rotationAngle = 180.0f;

        private float m_shipDistance = 0.0f;
        private float m_shipR = 0.0f;

        private float standCarrier = 0.0f;

        /// <summary>
        ///	 Ugao rotacije sveta oko X ose.
        /// </summary>
        private float m_xRotation = 10.0f;

        /// <summary>
        ///	 Ugao rotacije sveta oko Y ose.
        /// </summary>
        private float m_yRotation = -50.0f;

        /// <summary>
        ///	 Udaljenost scene od kamere.
        /// </summary>
        private float m_sceneDistance = 100.0f;

        /// <summary>
        ///	 Sirina OpenGL kontrole u pikselima.
        /// </summary>
        private int m_width;

        /// <summary>
        ///	 Visina OpenGL kontrole u pikselima.
        /// </summary>
        private int m_height;

        private Glu.GLUquadric gluObject;

        private OutlineFont outFont;

        #endregion Atributi

        #region Tekst atributi

        /// <summary>
        ///	 Promenljive za ispis
        /// </summary>
        private String predmet = "Predmet: Racunarska grafika";
        private String skolGod = "Sk. god: 2015/2016";
        private String ime = "Ime: Danilo";
        private String prezime = "Prezime: Mogin";
        private String sifraZad = "Sifra zad: 7.4";

        #endregion Atributi za text

        #region Properties

        /// <summary>
        ///	 Scena koja se prikazuje.
        /// </summary>
        public AssimpScene Scene
        {
            get { return m_scene; }
            set { m_scene = value; }
        }
        public float RotationAngle
        {
            get { return rotationAngle; }
            set { rotationAngle = value; standAngle = value; }
        }
        public float ShipDistance
        {
            get { return m_shipDistance; }
            set { m_shipDistance = value; }
        }

        public float BoxScaleX 
        {
            get { return boxScaleX; }
            set { boxScaleX = value; }
        }

        public float BoxScaleZ
        {
            get { return boxScaleZ; }
            set { boxScaleZ = value; }
        }

        /// <summary>
        ///	 Rastojanje broda od centra planete
        /// </summary>
        public float ShipR
        {
            get { return m_shipR; }
            set { m_shipR = value; }
        }

        /// <summary>
        ///	 Brzina rotacije broda
        /// </summary>
        public float RotationSpeed
        {
            get { return rotationSpeed; }
            set { rotationSpeed = value; }
        }

        /// <summary>
        ///	 Ugao rotacije sveta oko X ose.
        /// </summary>
        public float RotationX
        {
            get { return m_xRotation; }
            set { m_xRotation = value; }
        }

        /// <summary>
        ///	 Ugao rotacije sveta oko Y ose.
        /// </summary>
        public float RotationY
        {
            get { return m_yRotation; }
            set { m_yRotation = value; }
        }

        /// <summary>
        ///	 Udaljenost scene od kamere.
        /// </summary>
        public float SceneDistance
        {
            get { return m_sceneDistance; }
            set { m_sceneDistance = value; }
        }

        /// <summary>
        ///	 Sirina OpenGL kontrole u pikselima.
        /// </summary>
        public int Width
        {
            get { return m_width; }
            set { m_width = value; }
        }

        /// <summary>
        ///	 Visina OpenGL kontrole u pikselima.
        /// </summary>
        public int Height
        {
            get { return m_height; }
            set { m_height = value; }
        }

        public double ScaleShip
        {
            get { return scaleShip; }
            set { scaleShip = value; }
        }

        public float ShipHeight
        {
            get { return shipHeight; }
            set { shipHeight = value; }
        }

        public float StandCarrier
        {
            get { return standCarrier; }
            set { standCarrier = value; }
        }

        public float StandHeight
        {
            get { return standHeight; }
            set { standHeight = value; }
        }

        #endregion Properties

        #region Konstruktori

        /// <summary>
        ///  Konstruktor klase World.
        /// </summary>
        public World(String scenePath, String sceneFileName, int width, int height)
        {
            this.m_scene = new AssimpScene(scenePath, sceneFileName);
            this.m_width = width;
            this.m_height = height;  
            outFont = new OutlineFont("Arial",14.0f, 0.0f, false, false, true, false);
            m_textures = new int[m_textureCount];
            this.Initialize();  // Korisnicka inicijalizacija OpenGL parametara

            this.Resize();      // Podesi projekciju i viewport
        }

        /// <summary>
        ///  Destruktor klase World.
        /// </summary>
        ~World()
        {
            this.Dispose(false);
        }

        #endregion Konstruktori

        #region Metode

        /// <summary>
        ///  Iscrtavanje OpenGL kontrole.
        /// </summary>
        public void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            
            Gl.glPushMatrix();
            Gl.glTranslatef(0.0f, 0.0f, -m_sceneDistance);
            Gl.glRotatef(m_xRotation, 1.0f, 0.0f, 0.0f); //odamh za 10
            Gl.glRotatef(m_yRotation, 0.0f, 1.0f, 0.0f);

            //Tacka 6 faza 2: Pozicionirati kameru, tako da se vide deo planete, kao i bočna i gornja strana svemirskog broda.
            Glu.gluLookAt(-10.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);

            //Tacka 2 faza 2: Pozicionirati reflektorski izvor svetlosti ispod planete
            float[] positionLight1 = { -90.0f, -80.0f, 0.0f, 1.0f };
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, positionLight1);
       
            //Tacka 9 faza 2 Pozicionirati tackasti izvor svetlosti iznad broda
            float[] positionLight0 = { 0.0f, 40.0f, 0.0f, 1.0f };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, positionLight0);

            //planeta
            Gl.glPushMatrix();
            Gl.glTranslatef(0.0f, -80.0f, 0.0f);
            Gl.glColor3f(0.4f, 0.4f, 0.4f);
            Glu.gluQuadricNormals(gluObject, Glu.GLU_SMOOTH);
            Glu.gluQuadricTexture(gluObject, Gl.GL_TRUE);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, m_textures[(int)TextureObjects.Moon]);
            Glu.gluSphere(gluObject, 60.0f, 128, 128);
           
            Gl.glPopMatrix();
        
            //nosac postolja
            Gl.glPushMatrix();
            Gl.glTranslatef(0.0f, -50 + standCarrier, 0.0f);
            Gl.glRotatef(-90.0f, 1.0f, 0.0f, 0.0f);
            Gl.glColor3f(0.4f, 0.4f, 0.4f);
            Glu.gluQuadricNormals(gluObject, Glu.GLU_SMOOTH);
            Glu.gluQuadricTexture(gluObject, Gl.GL_TRUE);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, m_textures[(int)TextureObjects.Metal_light]);
            Glu.gluCylinder(gluObject, 10.0f, 5.0f, 40.0f, 128, 128);
            Gl.glPopMatrix();

            //postolje
            Gl.glPushMatrix();
            postolje = new Box(boxScaleX, 5.0, boxScaleZ);
            Gl.glTranslatef(0.0f, -10.0f + standHeight, 0.0f);
            Gl.glRotatef(standAngle, 0.0f, 1.0f, 0.0f);
            // Tacka 10 faza 2: Način stapanja teksture sa materijalom postolja postaviti na GL_ADD
            Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_ADD);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, m_textures[(int)TextureObjects.Metal_dark]);
            Gl.glMatrixMode(Gl.GL_TEXTURE);

            Gl.glPushMatrix();
            Gl.glScalef(0.3f, 0.3f, 0.3f);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glColor3f(0.2f, 0.2f, 0.2f);
            postolje.Draw();
            Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_MODULATE);

            Gl.glMatrixMode(Gl.GL_TEXTURE);
            Gl.glPopMatrix();

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPopMatrix();

            //brod
            Gl.glPushMatrix();
            Gl.glRotatef(m_rotationAngle, 0.0f, 1.0f, 0.0f);
            Gl.glTranslatef(m_shipDistance, -4.0f + shipHeight, m_shipR);
            Gl.glScaled(scaleShip, scaleShip, scaleShip);
            m_scene.Draw();
            Gl.glPopMatrix();

            //ona prva 
            Gl.glPopMatrix();

            //teskt
            Gl.glPushMatrix();
            Gl.glColor3f(1.0f, 0.0f, 0.0f);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(-15, 15, -15, 15);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glPushMatrix();
            Gl.glDisable(Gl.GL_LIGHTING);

            Gl.glPushMatrix();
            Gl.glTranslatef(-outFont.CalculateTextWidth(predmet) * -0.25f, 13.5f, 0.0f);
            outFont.DrawText(predmet);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslatef(-outFont.CalculateTextWidth(predmet) * -0.25f, 12.5f, 0.0f);
            outFont.DrawText(skolGod);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslatef(-outFont.CalculateTextWidth(predmet) * -0.25f, 11.5f, 0.0f);
            outFont.DrawText(ime);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslatef(-outFont.CalculateTextWidth(predmet) * -0.25f, 10.5f, 0.0f);
            outFont.DrawText(prezime);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslatef(-outFont.CalculateTextWidth(predmet) * -0.25f, 9.5f, 0.0f);
            outFont.DrawText(sifraZad);
            Gl.glPopMatrix();
            Gl.glPopMatrix();
            Gl.glPopMatrix();
            Resize();

            // Oznaci kraj iscrtavanja
            Gl.glFlush();
        }

        /// <summary>
        ///  Korisnicka inicijalizacija i podesavanje OpenGL parametara.
        /// </summary>
        private void Initialize()
        {
            // Boja pozadine je tamno plava
            Gl.glClearColor(0.0f, 0.0f, 0.2f, 1.0f);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_CULL_FACE);
            gluObject = Glu.gluNewQuadric();

            // Tacka 1 faza 2: Ukljuciti color tracking mehanizam i podesiti da se pozivom metode glColor
            // definise ambijentalna i difuzna komponenta materijala
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glColorMaterial(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE);

            Gl.glEnable(Gl.GL_LIGHTING);

            // Tacka 2 faza 2: Definisati reflektorski izvor (cut-off=30) bele boje, pozicionirati ga ispod planete (na negativnom
            // delu z-ose scene) i usmeriti ga ka planeti. Svetlosni izvor treba da bude stacioniran (tj. transformacije nad modelom
            // ne uticu na njega). Definisati normale za postolje. Za objekte koji se iscrtavaju pomocu GLU metoda podesiti
            // automatsko generisanje normala.
            float[] ambient = { 0.0f, 0.0f, 0.0f, 1.0f };
            float[] diffuse = { 1.0f, 1.0f, 1.0f, 1.0f };

            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT, ambient);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT, diffuse);
            float[] direction = { 0.0f, -1.0f, 0.0f };
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPOT_DIRECTION, direction);
            Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_SPOT_CUTOFF, 30.0f);

            Gl.glEnable(Gl.GL_LIGHT1);

            // Tacka 9 faza 2: Definisati tackasti svetlosni izvor narandzaste boje
            float[] ambient1 = { 0.0f, 0.0f, 0.0f, 1.0f };
            float[] diffuse1 = { 1.0f, 0.5f, 0.0f, 1.0f };

            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, ambient1);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, diffuse1);
            Gl.glLightf(Gl.GL_LIGHT0, Gl.GL_SPOT_CUTOFF, 180.0f);

            Gl.glEnable(Gl.GL_LIGHT0);

            // Tacka 3 faza 2: Nacin stapanja teksture sa materijalom modulate
           
            // 3.nacin stapanja teksture sa materijalom modulate
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_MODULATE);

            // Ucitaj slike i kreiraj teksture
            Gl.glGenTextures(m_textureCount, m_textures);
            for (int i = 0; i < m_textureCount; ++i)
            {
                // Pridruzi teksturu odgovarajucem identifikatoru
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, m_textures[i]);

                // Ucitaj sliku i podesi parametre teksture
                Bitmap image = new Bitmap(m_textureFiles[i]);
                // rotiramo sliku zbog koordinantog sistema opengl-a
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
                // RGBA format (dozvoljena providnost slike tj. alfa kanal)
                BitmapData imageData = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,
                                                      System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                Glu.gluBuild2DMipmaps(Gl.GL_TEXTURE_2D, (int)Gl.GL_RGBA8, image.Width, image.Height, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, imageData.Scan0);
                Gl.glTexParameteri((int)Gl.GL_TEXTURE_2D, (int)Gl.GL_TEXTURE_MIN_FILTER, (int)Gl.GL_LINEAR);		// Linear Filtering
                Gl.glTexParameteri((int)Gl.GL_TEXTURE_2D, (int)Gl.GL_TEXTURE_MAG_FILTER, (int)Gl.GL_LINEAR);		// Linear Filtering

                //  3. Za teksture podesiti wrapping da bude GL_REPEAT po obema osama
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);

                // 3. Podesiti filtere za teksture tako da se koristi mipmap linearno filtriranje.
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR_MIPMAP_LINEAR);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR_MIPMAP_LINEAR);


                image.UnlockBits(imageData);
                image.Dispose();
            }
           
        }

        /// <summary>
        /// Podesava viewport i projekciju za OpenGL kontrolu.
        /// </summary>
        public void Resize()
        {
            Gl.glViewport(0, 0, m_width, m_height); // kreiraj viewport po celom prozoru
            Gl.glMatrixMode(Gl.GL_PROJECTION);      // selektuj Projection Matrix
            Gl.glLoadIdentity();			        // resetuj Projection Matrix

            Glu.gluPerspective(50.0, (double)m_width / (double)m_height, 0.5, 20000.0);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);   // selektuj ModelView Matrix
            Gl.glLoadIdentity();                // resetuj ModelView Matrix
        }

        public void RotateStand()
        {
            if (rotationAngle == 360.0f)
            {
                rotationAngle = rotationSpeed;
            }
            else
            {
                rotationAngle += rotationSpeed;
                standAngle += rotationSpeed;
            }
        }

        public void RotateShip()
        {
            m_rotationAngle += 10.6f;
            if (m_rotationAngle > 360.0f)
            {
                m_rotationAngle = 0.0f;
            }
        }
        
        /// <summary>
        ///  Implementacija IDisposable interfejsa.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Oslodi managed resurse
            }

            // Oslobodi unmanaged resurse
            m_scene.Dispose();
            outFont.Dispose();
            Glu.gluDeleteQuadric(gluObject);
        }

        #endregion Metode

        #region IDisposable metode

        /// <summary>
        ///  Dispose metoda.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable metode
    }
}
