using System;

namespace Geekbrains
{
    public abstract class DisposeExample : IDisposable
    {
        private bool _disposed;


        public DisposeExample()
        {
            
        }
        
        // реализация интерфейса IDisposable.
        public void Dispose()
        {
            Dispose(true);
            // подавляем финализацию
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Освобождаем управляемые ресурсы
                }
                // освобождаем неуправляемые объекты
                _disposed = true;
            }
        }

        // Деструктор
        ~DisposeExample()
        {
            Dispose(false);
        }
    }

    public sealed class Derived : DisposeExample
    {
        private bool _isDisposed = false;

        protected override void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    // Освобождение управляемых ресурсов
                }
                _isDisposed = true;
            }
            // Обращение к методу Dispose базового класса
            base.Dispose(disposing);
        }
    }
}
