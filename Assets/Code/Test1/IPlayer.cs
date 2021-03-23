namespace Code.Test1
{
    public interface IPlayer
    {
        void Move();
    }
    
    public interface IUser
    {
        void Move();
    }

    internal class Enemy : IPlayer, IUser
    {
        void IPlayer.Move()
        {
            throw new System.NotImplementedException();
        }
        
        void IUser.Move()
        {
            throw new System.NotImplementedException();
        }

        public void Move()
        {
            
        }
    }

    internal class Example
    {
        private void Main()
        {
            Enemy enemy = new Enemy();
            ((IPlayer) enemy).Move();
            ((IUser) enemy).Move();
            enemy.Move();
        }
    }
}
