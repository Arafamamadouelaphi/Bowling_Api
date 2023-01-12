using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingLib.Model
{
    /// <summary>
    /// Classe Model Frame
    /// </summary>
    public class Frame:IEquatable<Frame>
    {
        const int MAX_QUILLE = 10;
        public int Numero
        {
            get
            { return numero; }
            set
            {
                this.numero = value;

            }
        }
        private int numero;

        private readonly long id;
        public long Id
        {
            get { return id; }
        }


        public int QuillesRestantes
        {
            get
            {
                return quillesRestantes;
            }
            private set
            {
                this.quillesRestantes = value;
            }
        }
        
        private int quillesRestantes;

        public int QuillesTombees
        {
            get
            {
                return quillesTombees;
            }
            set
            {
                this.quillesTombees = value;
            }
        }
        private int quillesTombees;

        public bool IsStrike
        {
            get
            {
                return isStrike;
            }
            set
            {
                this.isStrike = value;
            }
        }
        private bool isStrike;

        public bool IsSpare
        {
            get
            {
                return isPark;
            }
            set
            {
                this.isPark = value;
            }
        }
        private bool isPark;

        public bool IsFinished
        {
            get
            {
                return isFinished;
            }
            set
            {
                this.isFinished = value;
            }

        }

        private bool isFinished;

        public Lancer Lancer1
        {
            get
            {
                return lancer1;
            }
            set
            {
                this.lancer1 = value;
            }
        }
        private Lancer lancer1;

        public Lancer Lancer2
        {
            get { return lancer2; }
            set { this.lancer2 = value; }
        }
        private Lancer lancer2;
        public Lancer Lancer3
        {
            get { return lancer3; }
            set { this.lancer3 = value; }
        }
        private Lancer lancer3;

        /// <summary>
        /// Constructeur destiné à Initialisé un Frame
        /// </summary>
        /// <param name="numero"></param>
        public Frame(int numero)
        {
            this.Numero = numero;
            this.QuillesRestantes = MAX_QUILLE;
            this.IsFinished = false;
            this.IsStrike = false;
            this.IsSpare = false;
            this.QuillesTombees = 0;
        }

        /// <summary>
        /// Constructeur destiné à la récupération des données en base
        /// </summary>
        /// <param name="numero"></param>
        /// <param name="id"></param>
        /// <param name="lancer1"></param>
        /// <param name="lancer2"></param>
        /// <param name="lancer3"></param>
        public Frame(long id, int numero, int lancer1, int lancer2, int lancer3) : this(numero)
        {
            this.id = id;
            Lancer1 = new Lancer(lancer1);
            Lancer2 = new Lancer(lancer2);
            Lancer3 = new Lancer(lancer3);
        }

        /// <summary>
        /// Lance une quille
        /// </summary>
        /// <param name="quillesTombees">le nombre de quilles tombés </param>
        /// <exception cref="ArgumentException"></exception>
        public void Lancer(int quillesTombees)
        {
            if (quillesTombees > QuillesRestantes)
            {
                throw new ArgumentException("Le nombre de quilles tombees doit etre inferieur au nombre de quilles restantes");
            }
            if (quillesTombees < 0)
            {
                throw new ArgumentException("Le nombre de quilles tombees doit et etre positif");
            }

            if (this.Numero == MAX_QUILLE)
            {
                if (this.Lancer1 == null)
                {
                    this.Lancer1 = new Lancer(quillesTombees);
                    this.QuillesRestantes -= quillesTombees;
                    this.QuillesTombees += quillesTombees;
                    if (quillesTombees == MAX_QUILLE)
                    {
                        this.IsStrike = true;
                        QuillesRestantes = MAX_QUILLE;
                    }
                }
                else if (this.Lancer2 == null)
                {
                    this.Lancer2 = new Lancer(quillesTombees);
                    this.QuillesRestantes -= quillesTombees;
                    this.QuillesTombees += quillesTombees;
                    //lorsque le premier lancer est un strike
                    if (this.IsStrike)
                    {
                        if (quillesTombees == MAX_QUILLE)
                        {
                            //lorsque le lancer actuel est un strike
                            this.IsStrike = true;
                            QuillesRestantes = MAX_QUILLE;//Remetre le nombre de quilles restantes à 10 pour le lancer 3
                        }
                        else
                        {
                            this.IsStrike = false;
                        }
                    }
                    else
                    {
                        if (quillesTombees + this.Lancer1.QuillesTombees == MAX_QUILLE)
                        {
                            //lorsque le lancer actuel est un spare
                            this.IsSpare = true;
                            QuillesRestantes = MAX_QUILLE;//Remetre le nombre de quilles restantes à 10 pour le lancer 3
                        }
                    }
                }
                else if (this.Lancer3 == null)
                {
                    this.Lancer3 = new Lancer(quillesTombees);
                    this.QuillesRestantes -= quillesTombees;
                    this.QuillesTombees += quillesTombees;
                    if (this.IsStrike)//si le deuxième lancer etait un strike
                    {
                        if (quillesTombees == MAX_QUILLE)
                        {
                            this.IsStrike = true;//cas ou il effectue un 3eme strike
                        }
                        else
                        {
                            this.IsStrike = false;
                        }
                    }
                    else if (this.IsSpare)//si le deuxième lancer etait un spare
                    {
                        if (quillesTombees + this.Lancer2.QuillesTombees == MAX_QUILLE)
                        {
                            this.IsSpare = true;//cas ou il effectue un 3eme spare
                        }
                        else
                        {
                            this.IsSpare = false;
                        }
                    }
                    else
                    {
                        if (quillesTombees + this.Lancer2.QuillesTombees == MAX_QUILLE)
                        {
                            this.IsSpare = true;
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Le nombre de lancers est deja atteint");
                }
            }
            else
            {
                if (this.Lancer1 == null)
                {
                    this.Lancer1 = new Lancer(quillesTombees);
                }
                else if (this.Lancer2 == null)
                {
                    this.Lancer2 = new Lancer(quillesTombees);
                }
                else
                {
                    throw new ArgumentException("Le nombre de lancers est deja atteint");
                }
                this.QuillesRestantes -= quillesTombees;
                this.QuillesTombees += quillesTombees;
                if (quillesTombees == MAX_QUILLE)
                {
                    this.IsStrike = true;
                }
                else if (this.QuillesRestantes == 0)
                {
                    this.IsSpare = true;
                }
            }
            if (this.QuillesRestantes == 0 || (this.Lancer2 != null && this.Numero != MAX_QUILLE))
            {
                this.IsFinished = true;
            }
        }

        public bool Equals(Frame other)
        {
            return Numero.Equals(other.Numero);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Frame);
        }

        public override int GetHashCode()
        {
            return Numero.GetHashCode();
        }
    }
}
