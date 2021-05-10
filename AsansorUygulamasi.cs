using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Asansor
{
    public partial class AsansorUygulamasi : Form
    {
        Random rand = new Random();
        Musteri musteri = new Musteri();
        AsansorDurum asansorDurum = new AsansorDurum();
        ABilgi0 aBilgi0 = new ABilgi0();
        ABilgi1 aBilgi1 = new ABilgi1();
        ABilgi2 aBilgi2 = new ABilgi2();
        ABilgi3 aBilgi3 = new ABilgi3();
        ABilgi4 aBilgi4 = new ABilgi4();
        KatBilgi katBilgi = new KatBilgi();

        List<Giris> girisKuyrugu = new List<Giris>();
        List<ABilgi0> asansorK0 = new List<ABilgi0>();
        List<ABilgi1> asansorK1 = new List<ABilgi1>();
        List<ABilgi2> asansorK2 = new List<ABilgi2>();
        List<ABilgi3> asansorK3 = new List<ABilgi3>();
        List<ABilgi4> asansorK4 = new List<ABilgi4>();
        List<Acikis1> cikisK1 = new List<Acikis1>();
        List<Acikis2> cikisK2 = new List<Acikis2>();
        List<Acikis3> cikisK3 = new List<Acikis3>();
        List<Acikis4> cikisK4 = new List<Acikis4>();
        
        public class Musteri
        {
            public int toplam = 0;
        }
        public class AsansorDurum
        {
            public bool asansor0 = true;
            public bool asansor1 = false;
            public bool asansor2 = false;
            public bool asansor3 = false;
            public bool asansor4 = false;
        }
        public class ABilgi0
        {
            public int kisi = 0;
            public int asansorHedef = 0;
            public int toplam = 0;
            public bool kontrol = true;
        }
        public class ABilgi1
        {
            public int kisi = 0;
            public int asansorHedef = 0;
            public int toplam = 0;
            public bool kontrol = false;
        }
        public class Acikis1
        {
            public int cikacakMusteri = 0;
            public int cikisKati = 0;
        }
        public class ABilgi2
        {
            public int kisi = 0;
            public int asansorHedef = 0;
            public int toplam = 0;
            public bool kontrol = false;
        }
        public class Acikis2
        {
            public int cikacakMusteri = 0;
            public int cikisKati = 0;
        }
        public class ABilgi3
        {
            public int kisi = 0;
            public int asansorHedef = 0;
            public int toplam = 0;
            public bool kontrol = false;
        }
        public class Acikis3
        {
            public int cikacakMusteri = 0;
            public int cikisKati = 0;
        }
        public class ABilgi4
        {
            public int kisi = 0;
            public int asansorHedef = 0;
            public int toplam = 0;
            public bool kontrol = false;
        }
        public class Acikis4
        {
            public int cikacakMusteri = 0;
            public int cikisKati = 0;
        }
        public class KatBilgi
        {
            public int toplam1 = 0;
            public int toplam2 = 0;
            public int toplam3 = 0;
            public int toplam4 = 0;
            public int kuyrukToplam1 = 0;
            public int kuyrukToplam2 = 0;
            public int kuyrukToplam3 = 0;
            public int kuyrukToplam4 = 0;
        }
        public class Giris
        {
            public int musteriSayisi = 0;
            public int hedefKat = 0;
        }
        public AsansorUygulamasi()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        Thread baslangic, cikis, sonucYazdir, kontrol, asansor0;
        public void basla_btn_Click(object sender, EventArgs e)
        {
            baslangic = new Thread(AwmBaslangic);
            cikis = new Thread(AwmCikis);
            kontrol = new Thread(AsansorKontrol);
            asansor0 = new Thread(Asansor0);
            sonucYazdir = new Thread(Yazdir);
            baslangic.Start();
            kontrol.Start();
            asansor0.Start();
            cikis.Start();
            sonucYazdir.Start();
            basla_btn.Enabled = false;
        }

        public void AwmBaslangic()
        {
            int girisMusteri;
            int musterininGidecegiKat;
            while (true)
            {
                girisMusteri = rand.Next(1, 11);
                musterininGidecegiKat = rand.Next(1, 5);
                
                girisKuyrugu.Add(new Giris() {   
                    musteriSayisi = girisMusteri, 
                    hedefKat = musterininGidecegiKat
                });
                musteri.toplam += girisMusteri;
                Thread.Sleep(500);
            }
        }

        Thread asansor1, asansor2, asansor3, asansor4;
        public void AsansorKontrol()
        {
            asansor1 = new Thread(Asansor1);
            asansor2 = new Thread(Asansor2);
            asansor3 = new Thread(Asansor3);
            asansor4 = new Thread(Asansor4);
           
            int a1 = 0, a2 = 0, a3 = 0, a4 = 0;
            
            while (true)
            {
                if (baslangic != null && baslangic.IsAlive && baslangic.ThreadState != ThreadState.Suspended)
                {
                    if (musteri.toplam <= 20)
                    {
                        asansorDurum.asansor1 = false;
                        asansorDurum.asansor2 = false;
                        asansorDurum.asansor3 = false;
                        asansorDurum.asansor4 = false;
                    }
                    else if (musteri.toplam <= 40)
                    {
                        asansorDurum.asansor1 = true;
                        asansorDurum.asansor2 = false;
                        asansorDurum.asansor3 = false;
                        asansorDurum.asansor4 = false;
                        if (a1 == 0)
                        {
                            asansor1.Start();
                            a1++;
                        }
                    }
                    else if (musteri.toplam <= 60)
                    {
                        asansorDurum.asansor1 = true;
                        asansorDurum.asansor2 = true;
                        asansorDurum.asansor3 = false;
                        asansorDurum.asansor4 = false;
                        if (a2 == 0)
                        {
                            asansor2.Start();
                            a2++;
                        }
                    }
                    else if (musteri.toplam <= 80)
                    {
                        asansorDurum.asansor1 = true;
                        asansorDurum.asansor2 = true;
                        asansorDurum.asansor3 = true;
                        asansorDurum.asansor4 = false;
                        if (a3 == 0)
                        {
                            asansor3.Start();
                            a3++;
                        }
                    }
                    else
                    {
                        asansorDurum.asansor1 = true;
                        asansorDurum.asansor2 = true;
                        asansorDurum.asansor3 = true;
                        asansorDurum.asansor4 = true;
                        if (a4 == 0)
                        {
                            asansor4.Start();
                            a4++;
                        }
                    }
                }
            }
        }

        public void Asansor0()
        {
            int geciciToplam;
            tbDurum0.Text = "Aktif";

            while (true)
            {
                while (aBilgi0.toplam <= 10 && girisKuyrugu.Count != 0)
                {
                    geciciToplam = aBilgi0.toplam + girisKuyrugu[0].musteriSayisi;
                    if (geciciToplam > 10)
                        break;
                    asansorK0.Add(new ABilgi0()
                    {
                        kisi = girisKuyrugu[0].musteriSayisi,
                        asansorHedef = girisKuyrugu[0].hedefKat
                    });

                    musteri.toplam -= asansorK0[asansorK0.Count - 1].kisi;
                    girisKuyrugu.RemoveAt(0);
                    aBilgi0.toplam += asansorK0[asansorK0.Count - 1].kisi;

                    if (aBilgi0.toplam < 10 && girisKuyrugu.Count == 0)
                    {
                        break;
                    }
                }

                asansorK0 = asansorK0.OrderBy(x => x.asansorHedef).ToList();

                var ilkKat = asansorK0.Find(i => i.asansorHedef == 1);
                var ikinciKat = asansorK0.Find(i => i.asansorHedef == 2);
                var ucuncuKat = asansorK0.Find(i => i.asansorHedef == 3);
                var dorduncuKat = asansorK0.Find(i => i.asansorHedef == 4);

                aBilgi0.kontrol = true;
                Thread.Sleep(200);
                while (asansorK0.Contains(ilkKat))
                {
                    katBilgi.toplam1 += asansorK0[0].kisi;
                    aBilgi0.toplam -= asansorK0[0].kisi;

                    asansorK0.RemoveAt(0);
                    ilkKat = asansorK0.Find(i => i.asansorHedef == 1);
                }

                tbKonum0.Text = "1. Kat";
                Thread.Sleep(200);
                while (asansorK0.Contains(ikinciKat))
                {
                    katBilgi.toplam2 += asansorK0[0].kisi;

                    aBilgi0.toplam -= asansorK0[0].kisi;

                    asansorK0.RemoveAt(0);
                    ikinciKat = asansorK0.Find(i => i.asansorHedef == 2);
                }

                tbKonum0.Text = "2. Kat";
                Thread.Sleep(200);
                while (asansorK0.Contains(ucuncuKat))
                {
                    katBilgi.toplam3 += asansorK0[0].kisi;

                    aBilgi0.toplam -= asansorK0[0].kisi;

                    asansorK0.RemoveAt(0);
                    ucuncuKat = asansorK0.Find(i => i.asansorHedef == 3);
                }

                tbKonum0.Text = "3. Kat";
                Thread.Sleep(200);
                while (asansorK0.Contains(dorduncuKat))
                {
                    katBilgi.toplam4 += asansorK0[0].kisi;

                    aBilgi0.toplam -= asansorK0[0].kisi;

                    asansorK0.RemoveAt(0);
                    dorduncuKat = asansorK0.Find(i => i.asansorHedef == 4);
                }

                tbKonum0.Text = "4. Kat";
                aBilgi0.kontrol = false;
                Thread.Sleep(200);
                while (aBilgi0.toplam <= 10 && cikisK4.Count != 0 && katBilgi.kuyrukToplam4 != 0)
                {
                    geciciToplam = aBilgi0.toplam + cikisK4[0].cikacakMusteri;
                    if (geciciToplam > 10)
                        break;
                    asansorK0.Add(new ABilgi0()
                    {
                        kisi = cikisK4[0].cikacakMusteri,
                        asansorHedef = 0
                    });

                    katBilgi.kuyrukToplam4 -= asansorK0[asansorK0.Count - 1].kisi;
                    katBilgi.toplam4 -= asansorK0[asansorK0.Count - 1].kisi;
                    if (cikisK4.Count != 0)
                        cikisK4.RemoveAt(0);
                    aBilgi0.toplam += asansorK0[asansorK0.Count - 1].kisi;
                }
                tbKonum0.Text = "3. Kat";
                Thread.Sleep(200);
                while (aBilgi0.toplam <= 10 && cikisK3.Count != 0 && katBilgi.kuyrukToplam3 != 0)
                {
                    geciciToplam = aBilgi0.toplam + cikisK3[0].cikacakMusteri;
                    if (geciciToplam > 10)
                        break;
                    asansorK0.Add(new ABilgi0()
                    {
                        kisi = cikisK3[0].cikacakMusteri,
                        asansorHedef = 0
                    });

                    katBilgi.kuyrukToplam3 -= asansorK0[asansorK0.Count - 1].kisi;
                    katBilgi.toplam3 -= asansorK0[asansorK0.Count - 1].kisi;
                    if (cikisK3.Count != 0)
                        cikisK3.RemoveAt(0);
                    aBilgi0.toplam += asansorK0[asansorK0.Count - 1].kisi;
                }

                tbKonum0.Text = "2. Kat";
                Thread.Sleep(200);
                while (aBilgi0.toplam <= 10 && cikisK2.Count != 0 && katBilgi.kuyrukToplam2 != 0)
                {
                    geciciToplam = aBilgi0.toplam + cikisK2[0].cikacakMusteri;
                    if (geciciToplam > 10)
                        break;
                    asansorK0.Add(new ABilgi0()
                    {
                        kisi = cikisK2[0].cikacakMusteri,
                        asansorHedef = 0
                    });

                    katBilgi.kuyrukToplam2 -= asansorK0[asansorK0.Count - 1].kisi;
                    katBilgi.toplam2 -= asansorK0[asansorK0.Count - 1].kisi;
                    if (cikisK2.Count != 0)
                        cikisK2.RemoveAt(0);
                    aBilgi0.toplam += asansorK0[asansorK0.Count - 1].kisi;
                }
                tbKonum0.Text = "1. Kat";
                Thread.Sleep(200);
                while (aBilgi0.toplam <= 10 && cikisK1.Count != 0 && katBilgi.kuyrukToplam1 != 0)
                {
                    geciciToplam = aBilgi0.toplam + cikisK1[0].cikacakMusteri;
                    if (geciciToplam > 10)
                        break;
                    asansorK0.Add(new ABilgi0()
                    {
                        kisi = cikisK1[0].cikacakMusteri,
                        asansorHedef = 0
                    });

                    katBilgi.kuyrukToplam1 -= asansorK0[asansorK0.Count - 1].kisi;
                    katBilgi.toplam1 -= asansorK0[asansorK0.Count - 1].kisi;
                    if (cikisK1.Count != 0)
                        cikisK1.RemoveAt(0);
                    aBilgi0.toplam += asansorK0[asansorK0.Count - 1].kisi;
                }
                asansorK0.Clear();
                aBilgi0.toplam = 0;
                tbKonum0.Text = "Zemin Kat";
            }
        }
        public void Asansor1()
        {
            int geciciToplam;
            while (true)
            {
                if (asansorDurum.asansor1 == true)
                {
                    aBilgi1.kontrol = true;
                    while (aBilgi1.toplam <= 10 && girisKuyrugu.Count != 0)
                    {
                        geciciToplam = aBilgi1.toplam + girisKuyrugu[0].musteriSayisi;
                        if (geciciToplam > 10)
                            break;
                        asansorK1.Add(new ABilgi1()
                        {
                            kisi = girisKuyrugu[0].musteriSayisi,
                            asansorHedef = girisKuyrugu[0].hedefKat
                        });

                        musteri.toplam -= asansorK1[asansorK1.Count - 1].kisi;
                        girisKuyrugu.RemoveAt(0);
                        aBilgi1.toplam += asansorK1[asansorK1.Count - 1].kisi;
                    }

                    asansorK1 = asansorK1.OrderBy(x => x.asansorHedef).ToList();

                    var ilkKat = asansorK1.Find(i => i.asansorHedef == 1);
                    var ikinciKat = asansorK1.Find(i => i.asansorHedef == 2);
                    var ucuncuKat = asansorK1.Find(i => i.asansorHedef == 3);
                    var dorduncuKat = asansorK1.Find(i => i.asansorHedef == 4);

                    Thread.Sleep(200);
                    while (asansorK1.Contains(ilkKat))
                    {
                        katBilgi.toplam1 += asansorK1[0].kisi;
                        aBilgi1.toplam -= asansorK1[0].kisi;
                        asansorK1.RemoveAt(0);

                        ilkKat = asansorK1.Find(i => i.asansorHedef == 1);
                    }
                    tbKonum1.Text = "1. Kat";
                    Thread.Sleep(200);
                    while (asansorK1.Contains(ikinciKat))
                    {
                        katBilgi.toplam2 += asansorK1[0].kisi;
                        aBilgi1.toplam -= asansorK1[0].kisi;
                        asansorK1.RemoveAt(0);

                        ikinciKat = asansorK1.Find(i => i.asansorHedef == 2);
                    }
                    tbKonum1.Text = "2. Kat";
                    Thread.Sleep(200);
                    while (asansorK1.Contains(ucuncuKat))
                    {
                        katBilgi.toplam3 += asansorK1[0].kisi;

                        aBilgi1.toplam -= asansorK1[0].kisi;

                        asansorK1.RemoveAt(0);
                        ucuncuKat = asansorK1.Find(i => i.asansorHedef == 3);
                    }
                    tbKonum1.Text = "3. Kat";
                    Thread.Sleep(200);
                    while (asansorK1.Contains(dorduncuKat))
                    {
                        katBilgi.toplam4 += asansorK1[0].kisi;

                        aBilgi1.toplam -= asansorK1[0].kisi;

                        asansorK1.RemoveAt(0);
                        dorduncuKat = asansorK1.Find(i => i.asansorHedef == 4);
                    }

                    tbKonum1.Text = "4. Kat";
                    aBilgi1.kontrol = false;
                    Thread.Sleep(200);
                    while (aBilgi1.toplam <= 10 && cikisK4.Count != 0 && katBilgi.kuyrukToplam4 != 0)
                    {
                        geciciToplam = aBilgi1.toplam + cikisK4[0].cikacakMusteri;
                        if (geciciToplam > 10)
                            break;
                        asansorK1.Add(new ABilgi1()
                        {
                            kisi = cikisK4[0].cikacakMusteri,
                            asansorHedef = 0
                        });

                        katBilgi.kuyrukToplam4 -= asansorK1[asansorK1.Count - 1].kisi;
                        katBilgi.toplam4 -= asansorK1[asansorK1.Count - 1].kisi;
                        if (cikisK4.Count != 0)
                            cikisK4.RemoveAt(0);
                        aBilgi1.toplam += asansorK1[asansorK1.Count - 1].kisi;
                    }
                    tbKonum1.Text = "3. Kat";
                    Thread.Sleep(200);
                    while (aBilgi1.toplam <= 10 && cikisK3.Count != 0 && katBilgi.kuyrukToplam3 != 0)
                    {
                        geciciToplam = aBilgi1.toplam + cikisK3[0].cikacakMusteri;
                        if (geciciToplam > 10)
                            break;
                        asansorK1.Add(new ABilgi1()
                        {
                            kisi = cikisK3[0].cikacakMusteri,
                            asansorHedef = 0
                        });

                        katBilgi.kuyrukToplam3 -= asansorK1[asansorK1.Count - 1].kisi;
                        katBilgi.toplam3 -= asansorK1[asansorK1.Count - 1].kisi;
                        if (cikisK3.Count != 0)
                            cikisK3.RemoveAt(0);
                        aBilgi1.toplam += asansorK1[asansorK1.Count - 1].kisi;
                    }
                    tbKonum1.Text = "2. Kat";
                    Thread.Sleep(200);
                    while (aBilgi1.toplam <= 10 && cikisK2.Count != 0 && katBilgi.kuyrukToplam2 != 0)
                    {
                        geciciToplam = aBilgi1.toplam + cikisK2[0].cikacakMusteri;
                        if (geciciToplam > 10)
                            break;
                        asansorK1.Add(new ABilgi1()
                        {
                            kisi = cikisK2[0].cikacakMusteri,
                            asansorHedef = 0
                        });

                        katBilgi.kuyrukToplam2 -= asansorK1[asansorK1.Count - 1].kisi;
                        katBilgi.toplam2 -= asansorK1[asansorK1.Count - 1].kisi;
                        if (cikisK2.Count != 0)
                            cikisK2.RemoveAt(0);
                        aBilgi1.toplam += asansorK1[asansorK1.Count - 1].kisi;
                    }
                    tbKonum1.Text = "1. Kat";
                    Thread.Sleep(200);
                    while (aBilgi1.toplam <= 10 && cikisK1.Count != 0 && katBilgi.kuyrukToplam1 != 0)
                    {
                        geciciToplam = aBilgi1.toplam + cikisK1[0].cikacakMusteri;
                        if (geciciToplam > 10)
                            break;
                        asansorK1.Add(new ABilgi1()
                        {
                            kisi = cikisK1[0].cikacakMusteri,
                            asansorHedef = 0
                        });

                        katBilgi.kuyrukToplam1 -= asansorK1[asansorK1.Count - 1].kisi;
                        katBilgi.toplam1 -= asansorK1[asansorK1.Count - 1].kisi;
                        if (cikisK1.Count != 0)
                            cikisK1.RemoveAt(0);
                        aBilgi1.toplam += asansorK1[asansorK1.Count - 1].kisi;
                    }
                    asansorK1.Clear();
                    aBilgi1.toplam = 0;
                    tbKonum1.Text = "Zemin Kat";
                }
            }
        }
        public void Asansor2()
        {
            int geciciToplam;

            while (true)
            {
                if (asansorDurum.asansor2 == true)
                {
                    aBilgi2.kontrol = true;
                    while (aBilgi2.toplam <= 10 && girisKuyrugu.Count != 0)
                    {
                        geciciToplam = aBilgi2.toplam + girisKuyrugu[0].musteriSayisi;
                        if (geciciToplam > 10)
                            break;
                        asansorK2.Add(new ABilgi2()
                        {
                            kisi = girisKuyrugu[0].musteriSayisi,
                            asansorHedef = girisKuyrugu[0].hedefKat
                        });

                        musteri.toplam -= asansorK2[asansorK2.Count - 1].kisi;
                        girisKuyrugu.RemoveAt(0);
                        aBilgi2.toplam += asansorK2[asansorK2.Count - 1].kisi;
                    }

                    asansorK2 = asansorK2.OrderBy(x => x.asansorHedef).ToList();

                    var ilkKat = asansorK2.Find(i => i.asansorHedef == 1);
                    var ikinciKat = asansorK2.Find(i => i.asansorHedef == 2);
                    var ucuncuKat = asansorK2.Find(i => i.asansorHedef == 3);
                    var dorduncuKat = asansorK2.Find(i => i.asansorHedef == 4);

                    Thread.Sleep(200);
                    while (asansorK2.Contains(ilkKat))
                    {
                        katBilgi.toplam1 += asansorK2[0].kisi;
                        aBilgi2.toplam -= asansorK2[0].kisi;
                        asansorK2.RemoveAt(0);

                        ilkKat = asansorK2.Find(i => i.asansorHedef == 1);
                    }
                    tbKonum2.Text = "1. Kat";
                    Thread.Sleep(200);
                    while (asansorK2.Contains(ikinciKat))
                    {
                        katBilgi.toplam2 += asansorK2[0].kisi;
                        aBilgi2.toplam -= asansorK2[0].kisi;
                        asansorK2.RemoveAt(0);

                        ikinciKat = asansorK2.Find(i => i.asansorHedef == 2);
                    }
                    tbKonum2.Text = "2. Kat";
                    Thread.Sleep(200);
                    while (asansorK2.Contains(ucuncuKat))
                    {
                        katBilgi.toplam3 += asansorK2[0].kisi;

                        aBilgi2.toplam -= asansorK2[0].kisi;

                        asansorK2.RemoveAt(0);
                        ucuncuKat = asansorK2.Find(i => i.asansorHedef == 3);
                    }
                    tbKonum2.Text = "3. Kat";
                    Thread.Sleep(200);
                    while (asansorK2.Contains(dorduncuKat))
                    {
                        katBilgi.toplam4 += asansorK2[0].kisi;
                        aBilgi2.toplam -= asansorK2[0].kisi;

                        asansorK2.RemoveAt(0);
                        dorduncuKat = asansorK2.Find(i => i.asansorHedef == 4);
                    }
                    tbKonum2.Text = "4. Kat";
                    aBilgi2.kontrol = false;
                    Thread.Sleep(200);
                    while (aBilgi2.toplam <= 10 && cikisK4.Count != 0 && katBilgi.kuyrukToplam4 != 0)
                    {
                        geciciToplam = aBilgi2.toplam + cikisK4[0].cikacakMusteri;
                        if (geciciToplam > 10)
                            break;
                        asansorK2.Add(new ABilgi2()
                        {
                            kisi = cikisK4[0].cikacakMusteri,
                            asansorHedef = 0
                        });

                        katBilgi.kuyrukToplam4 -= asansorK2[asansorK2.Count - 1].kisi;
                        katBilgi.toplam4 -= asansorK2[asansorK2.Count - 1].kisi;
                        if (cikisK4.Count != 0)
                            cikisK4.RemoveAt(0);
                        aBilgi2.toplam += asansorK2[asansorK2.Count - 1].kisi;
                    }
                    tbKonum2.Text = "3. Kat";
                    Thread.Sleep(200);
                    while (aBilgi2.toplam <= 10 && cikisK3.Count != 0 && katBilgi.kuyrukToplam3 != 0)
                    {
                        geciciToplam = aBilgi2.toplam + cikisK3[0].cikacakMusteri;
                        if (geciciToplam > 10)
                            break;
                        asansorK2.Add(new ABilgi2()
                        {
                            kisi = cikisK3[0].cikacakMusteri,
                            asansorHedef = 0
                        });

                        katBilgi.kuyrukToplam3 -= asansorK2[asansorK2.Count - 1].kisi;
                        katBilgi.toplam3 -= asansorK2[asansorK2.Count - 1].kisi;
                        if (cikisK3.Count != 0)
                            cikisK3.RemoveAt(0);
                        aBilgi2.toplam += asansorK2[asansorK2.Count - 1].kisi;
                    }
                    tbKonum2.Text = "2. Kat";
                    Thread.Sleep(200);
                    while (aBilgi2.toplam <= 10 && cikisK2.Count != 0 && katBilgi.kuyrukToplam2 != 0)
                    {
                        geciciToplam = aBilgi2.toplam + cikisK2[0].cikacakMusteri;
                        if (geciciToplam > 10)
                            break;
                        asansorK2.Add(new ABilgi2()
                        {
                            kisi = cikisK2[0].cikacakMusteri,
                            asansorHedef = 0
                        });

                        katBilgi.kuyrukToplam2 -= asansorK2[asansorK2.Count - 1].kisi;
                        katBilgi.toplam2 -= asansorK2[asansorK2.Count - 1].kisi;
                        if (cikisK2.Count != 0)
                            cikisK2.RemoveAt(0);
                        aBilgi2.toplam += asansorK2[asansorK2.Count - 1].kisi;
                    }
                    tbKonum2.Text = "1. Kat";
                    Thread.Sleep(200);
                    while (aBilgi2.toplam <= 10 && cikisK1.Count != 0 && katBilgi.kuyrukToplam1 != 0)
                    {
                        geciciToplam = aBilgi2.toplam + cikisK1[0].cikacakMusteri;
                        if (geciciToplam > 10)
                            break;
                        asansorK2.Add(new ABilgi2()
                        {
                            kisi = cikisK1[0].cikacakMusteri,
                            asansorHedef = 0
                        });

                        katBilgi.kuyrukToplam1 -= asansorK2[asansorK2.Count - 1].kisi;
                        katBilgi.toplam1 -= asansorK2[asansorK2.Count - 1].kisi;
                        if (cikisK1.Count != 0)
                            cikisK1.RemoveAt(0);
                        aBilgi2.toplam += asansorK2[asansorK2.Count - 1].kisi;
                    }
                    asansorK2.Clear();
                    aBilgi2.toplam = 0;
                    tbKonum2.Text = "Zemin Kat";
                }
            }
        }
        public void Asansor3()
        {
            int geciciToplam;

            while (true)
            {
                if (asansorDurum.asansor3 == true)
                {
                    aBilgi3.kontrol = true;
                    while (aBilgi3.toplam <= 10 && girisKuyrugu.Count != 0)
                    {
                        geciciToplam = aBilgi3.toplam + girisKuyrugu[0].musteriSayisi;
                        if (geciciToplam > 10)
                            break;
                        asansorK3.Add(new ABilgi3()
                        {
                            kisi = girisKuyrugu[0].musteriSayisi,
                            asansorHedef = girisKuyrugu[0].hedefKat
                        });

                        musteri.toplam -= asansorK3[asansorK3.Count - 1].kisi;
                        girisKuyrugu.RemoveAt(0);
                        aBilgi3.toplam += asansorK3[asansorK3.Count - 1].kisi;
                    }

                    asansorK3 = asansorK3.OrderBy(x => x.asansorHedef).ToList();

                    var ilkKat = asansorK3.Find(i => i.asansorHedef == 1);
                    var ikinciKat = asansorK3.Find(i => i.asansorHedef == 2);
                    var ucuncuKat = asansorK3.Find(i => i.asansorHedef == 3);
                    var dorduncuKat = asansorK3.Find(i => i.asansorHedef == 4);

                    Thread.Sleep(200);
                    while (asansorK3.Contains(ilkKat))
                    {
                        katBilgi.toplam1 += asansorK3[0].kisi;
                        aBilgi3.toplam -= asansorK3[0].kisi;
                        asansorK3.RemoveAt(0);

                        ilkKat = asansorK3.Find(i => i.asansorHedef == 1);
                    }
                    tbKonum3.Text = "1. Kat";
                    Thread.Sleep(200);
                    while (asansorK3.Contains(ikinciKat))
                    {
                        katBilgi.toplam2 += asansorK3[0].kisi;
                        aBilgi3.toplam -= asansorK3[0].kisi;
                        asansorK3.RemoveAt(0);

                        ikinciKat = asansorK3.Find(i => i.asansorHedef == 2);
                    }
                    tbKonum3.Text = "2. Kat";
                    Thread.Sleep(200);
                    while (asansorK3.Contains(ucuncuKat))
                    {
                        katBilgi.toplam3 += asansorK3[0].kisi;

                        aBilgi3.toplam -= asansorK3[0].kisi;

                        asansorK3.RemoveAt(0);
                        ucuncuKat = asansorK3.Find(i => i.asansorHedef == 3);
                    }
                    tbKonum3.Text = "3. Kat";
                    Thread.Sleep(200);
                    while (asansorK3.Contains(dorduncuKat))
                    {
                        katBilgi.toplam4 += asansorK3[0].kisi;

                        aBilgi3.toplam -= asansorK3[0].kisi;

                        asansorK3.RemoveAt(0);
                        dorduncuKat = asansorK3.Find(i => i.asansorHedef == 4);
                    }

                    tbKonum3.Text = "4. Kat";
                    aBilgi3.kontrol = false;
                    Thread.Sleep(200);
                    while (aBilgi3.toplam <= 10 && cikisK4.Count != 0 && katBilgi.kuyrukToplam4 != 0)
                    {
                        geciciToplam = aBilgi3.toplam + cikisK4[0].cikacakMusteri;
                        if (geciciToplam > 10)
                            break;
                        asansorK3.Add(new ABilgi3()
                        {
                            kisi = cikisK4[0].cikacakMusteri,
                            asansorHedef = 0
                        });

                        katBilgi.kuyrukToplam4 -= asansorK3[asansorK3.Count - 1].kisi;
                        katBilgi.toplam4 -= asansorK3[asansorK3.Count - 1].kisi;
                        if (cikisK4.Count != 0)
                            cikisK4.RemoveAt(0);
                        aBilgi3.toplam += asansorK3[asansorK3.Count - 1].kisi;
                    }
                    tbKonum3.Text = "3. Kat";
                    Thread.Sleep(200);
                    while (aBilgi3.toplam <= 10 && cikisK3.Count != 0 && katBilgi.kuyrukToplam3 != 0)
                    {
                        geciciToplam = aBilgi3.toplam + cikisK3[0].cikacakMusteri;
                        if (geciciToplam > 10)
                            break;
                        asansorK3.Add(new ABilgi3()
                        {
                            kisi = cikisK3[0].cikacakMusteri,
                            asansorHedef = 0
                        });

                        katBilgi.kuyrukToplam3 -= asansorK3[asansorK3.Count - 1].kisi;
                        katBilgi.toplam3 -= asansorK3[asansorK3.Count - 1].kisi;
                        if (cikisK3.Count != 0)
                            cikisK3.RemoveAt(0);
                        aBilgi3.toplam += asansorK3[asansorK3.Count - 1].kisi;
                    }
                    tbKonum3.Text = "2. Kat";
                    Thread.Sleep(200);
                    while (aBilgi3.toplam <= 10 && cikisK2.Count != 0 && katBilgi.kuyrukToplam2 != 0)
                    {
                        geciciToplam = aBilgi3.toplam + cikisK2[0].cikacakMusteri;
                        if (geciciToplam > 10)
                            break;
                        asansorK3.Add(new ABilgi3()
                        {
                            kisi = cikisK2[0].cikacakMusteri,
                            asansorHedef = 0
                        });

                        katBilgi.kuyrukToplam2 -= asansorK3[asansorK3.Count - 1].kisi;
                        katBilgi.toplam2 -= asansorK3[asansorK3.Count - 1].kisi;
                        if (cikisK2.Count != 0)
                            cikisK2.RemoveAt(0);
                        aBilgi3.toplam += asansorK3[asansorK3.Count - 1].kisi;
                    }
                    tbKonum3.Text = "1. Kat";
                    Thread.Sleep(200);
                    while (aBilgi3.toplam <= 10 && cikisK1.Count != 0 && katBilgi.kuyrukToplam1 != 0)
                    {
                        geciciToplam = aBilgi3.toplam + cikisK1[0].cikacakMusteri;
                        if (geciciToplam > 10)
                            break;
                        asansorK3.Add(new ABilgi3()
                        {
                            kisi = cikisK1[0].cikacakMusteri,
                            asansorHedef = 0
                        });

                        katBilgi.kuyrukToplam1 -= asansorK3[asansorK3.Count - 1].kisi;
                        katBilgi.toplam1 -= asansorK3[asansorK3.Count - 1].kisi;
                        if (cikisK1.Count != 0)
                            cikisK1.RemoveAt(0);
                        aBilgi3.toplam += asansorK3[asansorK3.Count - 1].kisi;
                    }
                    asansorK3.Clear();
                    aBilgi3.toplam = 0;
                    tbKonum3.Text = "Zemin Kat";
                }
            }
        }
        public void Asansor4()
        {
            int geciciToplam;

            while (true)
            {
                if (asansorDurum.asansor4 == true)
                {
                    aBilgi4.kontrol = true;
                    while (aBilgi4.toplam <= 10 && girisKuyrugu.Count != 0)
                    {
                        geciciToplam = aBilgi4.toplam + girisKuyrugu[0].musteriSayisi;
                        if (geciciToplam > 10)
                            break;
                        asansorK4.Add(new ABilgi4()
                        {
                            kisi = girisKuyrugu[0].musteriSayisi,
                            asansorHedef = girisKuyrugu[0].hedefKat
                        });

                        musteri.toplam -= asansorK4[asansorK4.Count - 1].kisi;
                        girisKuyrugu.RemoveAt(0);
                        aBilgi4.toplam += asansorK4[asansorK4.Count - 1].kisi;
                    }

                    asansorK4 = asansorK4.OrderBy(x => x.asansorHedef).ToList();

                    var ilkKat = asansorK4.Find(i => i.asansorHedef == 1);
                    var ikinciKat = asansorK4.Find(i => i.asansorHedef == 2);
                    var ucuncuKat = asansorK4.Find(i => i.asansorHedef == 3);
                    var dorduncuKat = asansorK4.Find(i => i.asansorHedef == 4);

                    Thread.Sleep(200);
                    while (asansorK4.Contains(ilkKat))
                    {
                        katBilgi.toplam1 += asansorK4[0].kisi;
                        aBilgi4.toplam -= asansorK4[0].kisi;
                        asansorK4.RemoveAt(0);

                        ilkKat = asansorK4.Find(i => i.asansorHedef == 1);
                    }
                    tbKonum4.Text = "1. Kat";
                    Thread.Sleep(200);
                    while (asansorK4.Contains(ikinciKat))
                    {
                        katBilgi.toplam2 += asansorK4[0].kisi;
                        aBilgi4.toplam -= asansorK4[0].kisi;
                        asansorK4.RemoveAt(0);

                        ikinciKat = asansorK4.Find(i => i.asansorHedef == 2);
                    }
                    tbKonum4.Text = "2. Kat";
                    Thread.Sleep(200);
                    while (asansorK4.Contains(ucuncuKat))
                    {
                        katBilgi.toplam3 += asansorK4[0].kisi;

                        aBilgi4.toplam -= asansorK4[0].kisi;

                        asansorK4.RemoveAt(0);
                        ucuncuKat = asansorK4.Find(i => i.asansorHedef == 3);
                    }
                    tbKonum4.Text = "3. Kat";
                    Thread.Sleep(200);
                    while (asansorK4.Contains(dorduncuKat))
                    {
                        katBilgi.toplam4 += asansorK4[0].kisi;

                        aBilgi4.toplam -= asansorK4[0].kisi;

                        asansorK4.RemoveAt(0);
                        dorduncuKat = asansorK4.Find(i => i.asansorHedef == 4);
                    }

                    tbKonum4.Text = "4. Kat";
                    aBilgi4.kontrol = false;
                    Thread.Sleep(200);
                    while (aBilgi4.toplam <= 10 && cikisK4.Count != 0 && katBilgi.kuyrukToplam4 != 0)
                    {
                        geciciToplam = aBilgi4.toplam + cikisK4[0].cikacakMusteri;
                        if (geciciToplam > 10)
                            break;
                        asansorK4.Add(new ABilgi4()
                        {
                            kisi = cikisK4[0].cikacakMusteri,
                            asansorHedef = 0
                        });

                        katBilgi.kuyrukToplam4 -= asansorK4[asansorK4.Count - 1].kisi;
                        katBilgi.toplam4 -= asansorK4[asansorK4.Count - 1].kisi;
                        if (cikisK4.Count != 0)
                            cikisK4.RemoveAt(0);
                        aBilgi4.toplam += asansorK4[asansorK4.Count - 1].kisi;
                    }
                    tbKonum4.Text = "3. Kat";
                    Thread.Sleep(200);
                    while (aBilgi4.toplam <= 10 && cikisK3.Count != 0 && katBilgi.kuyrukToplam3 != 0)
                    {
                        geciciToplam = aBilgi4.toplam + cikisK3[0].cikacakMusteri;
                        if (geciciToplam > 10)
                            break;
                        asansorK4.Add(new ABilgi4()
                        {
                            kisi = cikisK3[0].cikacakMusteri,
                            asansorHedef = 0
                        });

                        katBilgi.kuyrukToplam3 -= asansorK4[asansorK4.Count - 1].kisi;
                        katBilgi.toplam3 -= asansorK4[asansorK4.Count - 1].kisi;
                        if (cikisK3.Count != 0)
                            cikisK3.RemoveAt(0);
                        aBilgi4.toplam += asansorK4[asansorK4.Count - 1].kisi;
                    }
                    tbKonum4.Text = "2. Kat";
                    Thread.Sleep(200);
                    while (aBilgi4.toplam <= 10 && cikisK2.Count != 0 && katBilgi.kuyrukToplam2 != 0)
                    {
                        geciciToplam = aBilgi4.toplam + cikisK2[0].cikacakMusteri;
                        if (geciciToplam > 10)
                            break;
                        asansorK4.Add(new ABilgi4()
                        {
                            kisi = cikisK2[0].cikacakMusteri,
                            asansorHedef = 0
                        });

                        katBilgi.kuyrukToplam2 -= asansorK4[asansorK4.Count - 1].kisi;
                        katBilgi.toplam2 -= asansorK4[asansorK4.Count - 1].kisi;
                        if (cikisK2.Count != 0)
                            cikisK2.RemoveAt(0);
                        aBilgi4.toplam += asansorK4[asansorK4.Count - 1].kisi;
                    }
                    tbKonum4.Text = "1. Kat";
                    Thread.Sleep(200);
                    while (aBilgi4.toplam <= 10 && cikisK1.Count != 0 && katBilgi.kuyrukToplam1 != 0)
                    {
                        geciciToplam = aBilgi4.toplam + cikisK1[0].cikacakMusteri;
                        if (geciciToplam > 10)
                            break;
                        asansorK4.Add(new ABilgi4()
                        {
                            kisi = cikisK1[0].cikacakMusteri,
                            asansorHedef = 0
                        });

                        katBilgi.kuyrukToplam1 -= asansorK4[asansorK4.Count - 1].kisi;
                        katBilgi.toplam1 -= asansorK4[asansorK4.Count - 1].kisi;
                        if (cikisK1.Count != 0)
                            cikisK1.RemoveAt(0);
                        aBilgi4.toplam += asansorK4[asansorK4.Count - 1].kisi;
                    }
                    asansorK4.Clear();
                    aBilgi4.toplam = 0;
                    tbKonum4.Text = "Zemin Kat";
                }
            }
        }
        public void Yazdir()
        {
            while (true)
            {
                Thread.Sleep(100);
                var temp = "";

                // 0. Asansör
                tbZeminKuyrukSayi.Text = musteri.toplam.ToString();
                tbZeminToplam.Text = musteri.toplam.ToString();
                temp = aBilgi0.kontrol ? tbYon0.Text = "Yukarı" : tbYon0.Text = "Aşağı";
                lbZeminKuyruk.Items.Clear();
                foreach (var kuyruk in girisKuyrugu.ToList())
                {
                    lbZeminKuyruk.Items.Add("[" + kuyruk.musteriSayisi + " , " + kuyruk.hedefKat + "]");
                }

                tbToplam0.Text = aBilgi0.toplam.ToString();
                lbBilgi0.Items.Clear();
                foreach (var kuyruk in asansorK0.ToList())
                {
                    lbBilgi0.Items.Add("[" + kuyruk.kisi + " , " + kuyruk.asansorHedef + "]");
                }

                // 1. Asansör
                temp = asansorDurum.asansor1 ? tbDurum1.Text = "Aktif" : tbDurum1.Text = "Pasif";
                if (temp == "Aktif")
                    temp = aBilgi1.kontrol ? tbYon1.Text = "Yukarı" : tbYon1.Text = "Aşağı";
                else
                    tbYon1.Text = "";

                tbToplam1.Text = aBilgi1.toplam.ToString();
                lbBilgi1.Items.Clear();
                foreach (var kuyruk in asansorK1.ToList())
                {
                    lbBilgi1.Items.Add("[" + kuyruk.kisi + " , " + kuyruk.asansorHedef + "]");
                }

                tbKat1KuyrukSayi.Text = katBilgi.kuyrukToplam1.ToString();
                lbKat1Kuyruk.Items.Clear();
                foreach (var kuyruk in cikisK1.ToList())
                {
                    if (kuyruk.cikisKati == 1)
                    {
                        lbKat1Kuyruk.Items.Add("[" + kuyruk.cikacakMusteri + " , " + 0 + "]");
                    }
                }

                // 2. Asansör
                temp = asansorDurum.asansor2 ? tbDurum2.Text = "Aktif" : tbDurum2.Text = "Pasif";
                if (asansorDurum.asansor2)
                {
                    temp = aBilgi2.kontrol ? tbYon2.Text = "Yukarı" : tbYon2.Text = "Aşağı";
                    tbToplam2.Text = aBilgi2.toplam.ToString();
                    lbBilgi2.Items.Clear();
                    foreach (var kuyruk in asansorK2.ToList())
                    {
                        lbBilgi2.Items.Add("[" + kuyruk.kisi + " , " + kuyruk.asansorHedef + "]");
                    }
                }
                else
                {
                    tbYon2.Text = "";
                    lbBilgi2.Items.Clear();
                    tbToplam2.Text = "";
                }

                tbKat2KuyrukSayi.Text = katBilgi.kuyrukToplam2.ToString();
                lbKat2Kuyruk.Items.Clear();
                foreach (var kuyruk in cikisK2.ToList())
                {
                    if (kuyruk.cikisKati == 2)
                    {
                        lbKat2Kuyruk.Items.Add("[" + kuyruk.cikacakMusteri + " , " + 0 + "]");
                    }
                }

                // 3. Asansör
                temp = asansorDurum.asansor3 ? tbDurum3.Text = "Aktif" : tbDurum3.Text = "Pasif";
                if (asansorDurum.asansor3)
                {
                    temp = aBilgi3.kontrol ? tbYon3.Text = "Yukarı" : tbYon3.Text = "Aşağı";
                    tbToplam3.Text = aBilgi3.toplam.ToString();
                    lbBilgi3.Items.Clear();
                    foreach (var kuyruk in asansorK3.ToList())
                    {
                        lbBilgi3.Items.Add("[" + kuyruk.kisi + " , " + kuyruk.asansorHedef + "]");
                    }
                }
                else
                {
                    tbYon3.Text = "";
                    lbBilgi3.Items.Clear();
                    tbToplam3.Text = "";
                }

                tbKat3KuyrukSayi.Text = katBilgi.kuyrukToplam3.ToString();
                lbKat3Kuyruk.Items.Clear();
                foreach (var kuyruk in cikisK3.ToList())
                {
                    if (kuyruk.cikisKati == 3)
                    {
                        lbKat3Kuyruk.Items.Add("[" + kuyruk.cikacakMusteri + " , " + 0 + "]");
                    }
                }

                // 4. Asansör
                temp = asansorDurum.asansor4 ? tbDurum4.Text = "Aktif" : tbDurum4.Text = "Pasif";
                if (asansorDurum.asansor4)
                {
                    temp = aBilgi4.kontrol ? tbYon4.Text = "Yukarı" : tbYon4.Text = "Aşağı";
                    tbToplam4.Text = aBilgi4.toplam.ToString();
                    lbBilgi4.Items.Clear();
                    foreach (var kuyruk in asansorK4.ToList())
                    {
                        lbBilgi4.Items.Add("[" + kuyruk.kisi + " , " + kuyruk.asansorHedef + "]");
                    }
                }
                else
                {
                    tbYon4.Text = "";
                    lbBilgi4.Items.Clear();
                    tbToplam4.Text = "";
                }

                tbKat4KuyrukSayi.Text = katBilgi.kuyrukToplam4.ToString();
                lbKat4Kuyruk.Items.Clear();
                foreach (var kuyruk in cikisK4.ToList())
                {
                    if (kuyruk.cikisKati == 4)
                    {
                        lbKat4Kuyruk.Items.Add("[" + kuyruk.cikacakMusteri + " , " + 0 + "]");
                    }
                }

                // Katlardaki toplam müşteri sayıları
                tbKat1Toplam.Text = katBilgi.toplam1.ToString();
                tbKat2Toplam.Text = katBilgi.toplam2.ToString();
                tbKat3Toplam.Text = katBilgi.toplam3.ToString();
                tbKat4Toplam.Text = katBilgi.toplam4.ToString();
                if (katBilgi.kuyrukToplam1 < 0)
                    katBilgi.kuyrukToplam1 = 0;
                if (katBilgi.kuyrukToplam2 < 0)
                    katBilgi.kuyrukToplam2 = 0;
                if (katBilgi.kuyrukToplam3 < 0)
                    katBilgi.kuyrukToplam3 = 0;
                if (katBilgi.kuyrukToplam4 < 0)
                    katBilgi.kuyrukToplam4 = 0;
            }
        }
        public void AwmCikis()
        {
            int cikisMusteri;
            int cikisKati;
            while (true)
            {
                if (katBilgi.toplam1 >= 5 || katBilgi.toplam2 >= 5 || katBilgi.toplam3 >= 5 || katBilgi.toplam4 >= 5)
                {
                    cikisMusteri = rand.Next(1, 6);
                    cikisKati = rand.Next(1, 5);

                    if (cikisKati == 1 && katBilgi.toplam1 >= 5)
                    {
                        cikisK1.Add(new Acikis1()
                        {
                            cikacakMusteri = cikisMusteri,
                            cikisKati = cikisKati
                        });
                        katBilgi.kuyrukToplam1 += cikisMusteri;
                    }
                    else if (cikisKati == 2 && katBilgi.toplam2 >= 5)
                    {
                        cikisK2.Add(new Acikis2()
                        {
                            cikacakMusteri = cikisMusteri,
                            cikisKati = cikisKati
                        });
                        katBilgi.kuyrukToplam2 += cikisMusteri;
                    }
                    else if (cikisKati == 3 && katBilgi.toplam3 >= 5)
                    {
                        cikisK3.Add(new Acikis3()
                        {
                            cikacakMusteri = cikisMusteri,
                            cikisKati = cikisKati
                        });
                        katBilgi.kuyrukToplam3 += cikisMusteri;
                    }
                    else if (cikisKati == 4 && katBilgi.toplam4 >= 5)
                    {
                        cikisK4.Add(new Acikis4()
                        {
                            cikacakMusteri = cikisMusteri,
                            cikisKati = cikisKati
                        });
                        katBilgi.kuyrukToplam4 += cikisMusteri;
                    }
                    Thread.Sleep(1000);
                }
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (baslangic != null && baslangic.IsAlive)
            {
                baslangic.Suspend();
                kontrol.Suspend();
                sonucYazdir.Suspend();
                cikis.Suspend();
                asansor0.Suspend();
                if(asansor1 != null && asansor1.IsAlive)
                    asansor1.Suspend();
                if (asansor2 != null && asansor2.IsAlive)
                    asansor2.Suspend();
                if (asansor3 != null && asansor3.IsAlive)
                    asansor3.Suspend();
                if (asansor4 != null && asansor4.IsAlive)
                    asansor4.Suspend();
            }
        }

        private void devam_et_btn_Click(object sender, EventArgs e)
        {
            if (baslangic != null && baslangic.ThreadState == ThreadState.Suspended)
            {
                baslangic.Resume();
                kontrol.Resume();
                sonucYazdir.Resume();
                cikis.Resume();
                asansor0.Resume();
                if (asansor1 != null && asansor1.ThreadState == ThreadState.Suspended)
                    asansor1.Resume();
                if (asansor2 != null && asansor2.ThreadState == ThreadState.Suspended)
                    asansor2.Resume();
                if (asansor3 != null && asansor3.ThreadState == ThreadState.Suspended)
                    asansor3.Resume();
                if (asansor4 != null && asansor4.ThreadState == ThreadState.Suspended)
                    asansor4.Resume();
            }
        }
    }
}
