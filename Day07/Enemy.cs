using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console2048
{
    class Enemy
    {
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        private int blood;
        public int Blood
        {
            get
            {
                return this.blood;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    this.blood = value;
                }
            }
        }
        public Enemy(string name,int blood)
        {
            this.Name = name;
            this.Blood = blood;
        }
    }
}
