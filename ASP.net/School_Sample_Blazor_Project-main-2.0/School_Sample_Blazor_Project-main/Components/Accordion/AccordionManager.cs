namespace BlazorWebAppMovies.Components.Accordion
{
    public class AccordionManager
    {
        private int? CurrentAccordionIdOpen;

        public void Open(int AccordionId)
        {
            CurrentAccordionIdOpen = AccordionId;
        }

        public bool isOpen(int AccordionId)
        {
            return CurrentAccordionIdOpen == AccordionId;
        }
    }
}
