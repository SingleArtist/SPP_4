using System;
using System.Runtime.InteropServices;

//Задание 4
/*Создать класс на языке C#, который:
- называется OSHandle и обеспечивает автоматическое или
принудительное освобождение заданного дескриптора
операционной системы; -содержит свойство Handle, позволяющее установить и получить
дескриптор операционной системы;
-реализует метод Finalize для автоматического освобождения
дескриптора;
-реализует интерфейс IDisposable для принудительного
освобождения дескриптора;*/

namespace FourthTask
{
    class OSHandle 
    {
        [DllImport("Kernel32")]
        private static extern bool CloseHandle(IntPtr hObject);

        public IntPtr hObject;
        private bool _isDisposed;

        public OSHandle(IntPtr hObject)
        {
            if (hObject == IntPtr.Zero)
            {
                throw new ArgumentException("Сan't be null");
            }

            this.hObject = hObject;
        }

        ~OSHandle()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                CloseHandle(hObject);
                _isDisposed = true;
            }
        }
    }
}
