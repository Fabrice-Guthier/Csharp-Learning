namespace CDA
{
    public abstract class AbstractGestionnaireNombreAleatoire
    {
        public int NombreAleatoire { get; set; }

        public abstract int DeterminerLeNombreMaximum();
        public abstract void GenererNombreAleatoire();
    }
}