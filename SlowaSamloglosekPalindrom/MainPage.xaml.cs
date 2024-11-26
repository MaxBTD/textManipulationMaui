namespace SlowaSamloglosekPalindrom
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private string pobierzZdanie()
        {
            string zdanie = String.Empty;
            if(!String.IsNullOrEmpty(entZdanie.Text))
            {
                zdanie = entZdanie.Text.Trim().Replace("  ", " ").ToLower();
            }
            
            return zdanie;
        }

        private void onAnagClicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(entAn1.Text) && !String.IsNullOrEmpty(entAn2.Text))
            {
                string anag1 = !String.IsNullOrEmpty(entAn1.Text) ? entAn1.Text.Trim().Replace("  ", "").Replace(" ", "").ToLower() : "";
                string anag2 = !String.IsNullOrEmpty(entAn1.Text) ? entAn2.Text.Trim().Replace("  ", " ").Replace(" ", "").ToLower() : "";
                char[] znakiAnag1 = anag1.ToCharArray();

                if (anag1.Length == anag2.Length)
                {
                    foreach(char c in znakiAnag1)
                    {
                        for(int i = 0; i < anag2.Length; i++)
                        {
                            if (anag2[i] == c)
                            {
                                anag2 = anag2.Replace(c, ' ');
                            }
                        }
                        
                    }
                }

                lblResults.Text = String.IsNullOrWhiteSpace(anag2) ? "Wyrazy są anagrami" : "Wyrazy nie są anagrami";
            }
        }

        private void onPalinClicked(object sender, EventArgs e)
        {
            string zdanie = pobierzZdanie().Replace(" ","");
            string odwrotZdanie = "";
            for(int i = zdanie.Length - 1; i >= 0; i--)
            {
                odwrotZdanie += zdanie[i];
            }

            lblResults.Text = odwrotZdanie == zdanie ? $"Tak" : $"Nie"; 
        }

        private void onSamoClicked(object sender, EventArgs e)
        {
            string zdanie = pobierzZdanie();
            char[] samogloski = { 'a', 'e', 'i', 'o', 'u', 'y' };
            int liczbaSamo = 0;

            for (int i = 0; i < zdanie.Length; i++)
            {
                if (samogloski.Contains(zdanie[i]))
                    liczbaSamo++;
            }

            lblResults.Text = $"Policzono {liczbaSamo.ToString()} samogłosek";
        }

        private void onSlowaClicked(object sender, EventArgs e)
        {
            string zdanie = pobierzZdanie();
            int liczbaSlow = String.IsNullOrEmpty(zdanie) ? 0 : 1;

            for (int i = 0; i < zdanie.Length; i++)
            {
                if (zdanie[i] == ' ')
                    liczbaSlow++;
            }

            lblResults.Text = $"Policzono {liczbaSlow.ToString()} słów";
        }
    }

}
