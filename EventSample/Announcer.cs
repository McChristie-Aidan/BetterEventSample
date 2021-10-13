using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSample
{
    class Announcer
    {
        public List<Enemy> enemies;

        public int damageAmount = 1;

        public Announcer()
        {
            enemies = new List<Enemy>();
            FillList(5);
        }

        private void E_OnTakeDamage(object sender, EventArgs e)
        {
            Enemy enemy = (Enemy)sender;
            Console.WriteLine(enemy.hurtNoise);
        }

        public void AddEnemy(Enemy e)
        {
            enemies.Add(e);
            e.OnTakeDamage += E_OnTakeDamage;
        }

        public void RemoveEnemy(Enemy e)
        {
            enemies.Remove(e);
            e.OnTakeDamage -= E_OnTakeDamage;
        }

        private void FillList(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Enemy e = new Enemy();
                AddEnemy(e);
            }
        }

        public void HurtAllEnemies()
        {
            foreach (Enemy e in enemies)
            {
                e.TakeDamage();
            }
        }
    }
}
