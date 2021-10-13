using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSample
{
    class Enemy
    {
        public int Health { get; set; }

        public event EventHandler OnTakeDamage;

        public string hurtNoise;

        /*
         * this is just to test while i have minimal functionality.
         * i should have a method to get the damage number from whatever source the damage has come from
         */
        int damageAmount = 1;

        public Enemy()
        {
            this.hurtNoise = GetHurtNoise();
            this.OnTakeDamage += onTakeDamage;
        }

        public void TakeDamage()
        {
            this.OnTakeDamage.Invoke(this, EventArgs.Empty);
        }
        protected void onTakeDamage(object sender, EventArgs e)
        {
            this.Health--;
        }

        string GetHurtNoise()
        {
            string result = "";

            Random random = new Random();
            string[] hurtMessages = {"Ow!", "Ouch!", "Owie", "Oof!", "Hey!" };

            result = hurtMessages[random.Next(0, hurtMessages.Length)];

            return result;
        }
    }
}
