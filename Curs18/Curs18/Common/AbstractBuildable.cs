using Curs18.Enums;
using System;

namespace Curs18.Common
{
    public abstract class AbstractBuildable : AbstractSubject, IBuildable
    {
        #region Private Fields
        private Position position;
        private int percentageBuilt;
        private State state;
        private string name;
        private int cost = 0;
        private int life = 0;
        protected TerrainType ownTerrainType;
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public int PercentageBuilt
        {
            get
            {
                return percentageBuilt;
            }

            set
            {
                percentageBuilt = value;
                OnPropertyChanged("PercentageBuilt");
            }
        }

        public State State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
                OnPropertyChanged("State");
            }
        }

        public Position Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
                OnPropertyChanged("Position");
            }
        }

        public int Life
        {
            get
            {
                return life;
            }

            set
            {
                life = value;
                OnPropertyChanged("Life");
            }
        }

        public int Cost
        {
            get
            {
                return cost;
            }

            set
            {
                cost = value;
                OnPropertyChanged("Cost");
            }
        }
        #endregion

        #region Public Methods
       

        public virtual void StartBuilding()
        {
            State = State.UNDER_CONSTRUCTION;
        }

        public void Ready(int percentage)
        {
            if (percentage >= 100)
            {
                Ready();
            }
        }

        public virtual int GetCost()
        {
            return Cost;
        }

        public virtual int GetLife()
        {
            return Life;
        }
        #endregion


        private void Ready()
        {
            State = State.READY;
        }
    }
}
