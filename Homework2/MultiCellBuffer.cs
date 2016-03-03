using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

namespace Homework2
{
    class MultiCellBuffer
    {
        public static ArrayList buffer = new ArrayList();
        public static Semaphore sem;

        public MultiCellBuffer()
        {
            sem = new Semaphore(0, 3);
            sem.Release(3);
        }

        public void setOne(String order)
        {
            if (buffer.Count < 3)
            {
                sem.WaitOne();
                buffer.Add(order);
                string[] parts = order.Split(new string[] { ":" }, StringSplitOptions.None);
            }
        }

        public String getOne(string hotelname)
        {
            if (buffer.Count > 0)
            {
                for (int i = 0; i < buffer.Count; i++)
                {
                    try
                    {
                        {
                            String singleorder = (String)buffer[i];
                            
                            if (hotelname != null)
                            {
                                if (singleorder.Contains(hotelname))
                                {
                                    buffer.Remove(singleorder);
                                    sem.Release();
                                    string[] parts = singleorder.Split(new string[] { ":" }, StringSplitOptions.None);
                                    return singleorder;
                                }
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }
            return null;
        }

    }

    }

