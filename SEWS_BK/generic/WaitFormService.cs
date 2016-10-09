using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SEWS_BK.generic
{
    public class WaitFormService
    {
        public static void CreateWaitForm()
        {
            try
            { WaitFormService.Instance.CreateForm(); }
            catch
            { }
        }

        public static void CreateWaitForm(string text)
        {
            try
            { WaitFormService.Instance.CreateForm(text); }
            catch
            { }
        }

        public static void CloseWaitForm()
        {
            try
            { WaitFormService.Instance.CloseForm(); }
            catch
            { }
        }

        private static WaitFormService _instance;
        private static readonly Object syncLock = new Object();

        public static WaitFormService Instance
        {
            get
            {
                if (WaitFormService._instance == null)
                {
                    lock (syncLock)
                    {
                        if (WaitFormService._instance == null)
                        {
                            WaitFormService._instance = new WaitFormService();
                        }
                    }
                }
                return WaitFormService._instance;
            }
        }

        private WaitFormService()
        {
        }

        private Thread waitThread;
        private WaitForm waitForm;

        public void CreateForm()
        {
            if (waitThread != null)
            {
                try
                {
                    waitThread.Abort();
                }
                catch (Exception)
                {
                }
            }

            waitThread = new Thread(new ThreadStart(delegate()
            {
                waitForm = new WaitForm();
                //Application.Run(waitForm);
                waitForm.ShowDialog();
            }));
            waitThread.Start();
        }

        public void CreateForm(string text)
        {
            if (waitThread != null)
            {
                try
                {
                    waitThread.Abort();
                }
                catch (Exception)
                {
                }
            }

            waitThread = new Thread(new ThreadStart(delegate()
            {
                waitForm = new WaitForm(text);
                //Application.Run(waitForm);
                waitForm.ShowDialog();
            }));
            waitThread.Start();
        }

        public void CloseForm()
        {
            if (waitThread != null)
            {
                try
                {
                    waitThread.Abort();
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
