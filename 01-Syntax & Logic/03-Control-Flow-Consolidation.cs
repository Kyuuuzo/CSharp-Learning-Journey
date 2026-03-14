/*
 * =======================================================================
 * PROJECT  : CSharp-Learning-Journey
 * TOPIC    : Control Flow Consolidation
 * MODULE   : 01-Basic
 * AUTHOR   : Kyuuuzo
 * DATE     : 14 Maret 2026
 * * DESCRIPTION:
 * Modul ini merupakan tahap pemantapan logika pemrograman C# yang berfokus 
 * pada sinkronisasi alur kontrol dalam simulasi manajemen sumber daya. 
 * Fokus utama terletak pada penggunaan variabel kontrol (index) sebagai 
 * penghubung antar-array (Parallel Arrays) untuk mengelola data alat, 
 * biaya, dan energi secara dinamis. Program ini mengintegrasikan struktur 
 * Switch-Case untuk manajemen aksi, While Loop sebagai inti siklus permainan, 
 * serta implementasi logika acak (Random) dan validasi input (TryParse) 
 * guna menciptakan program yang interaktif, stabil, dan bebas dari crash.
 * =======================================================================
 */


using System;

class Program
{
    static void Main(string[] args)
    {
        int energi = 100;
        int energiMax = 100;
        int uang = 250;
        int hari = 1;
        int potion = 0;
        int goal = 80000;

        var penghasilan = new Random();

        var jenisBeliung = new[] { "Beliung Kayu", "Beliung Batu", "Beliung Besi" };
        int pakai = 0;
        var hargaBeliung = new[] { 0, 100, 200 };
        var kurasEnergi = new[] { 50, 38, 20 };

        var beliungTerbeli = new[] { true, false, false };
        bool sedangMenambang = true;

        while (sedangMenambang)
        {
            Console.Clear();
            Console.WriteLine($"|==-==-==-==-==- Hari ke {hari} | Goal: {uang} / {goal} -==-==-==-==-==|\n\n" +
                $"Energi            = {energi}\n" +
                $"Uang              = {uang}\n" +
                $"Potion Terpakai   = {potion}\n" +
                $"Beliung           = {jenisBeliung[pakai]}\n\n" +
                $"Pilihan Anda:\n" +
                $"1. Menambang -- Menguras {kurasEnergi[pakai]}\n" +
                $"2. Beli Potion -- Harga 125R, Menambah Energi 45\n" +
                $"3. Ganti Beliung.\n" +
                $"4. Tidur\n" +
                $"Pilihan: ");

            int pilihan;
            while (!int.TryParse(Console.ReadLine(), out pilihan) || pilihan < 1 || pilihan > 4)
            {
                Console.Write("Pilihan tidak valid. Masukkan angka 1, 2, 3 atau 4: ");
            }

            switch (pilihan)
            {
                case 1:
                    if (energi >= kurasEnergi[pakai])
                    {
                        energi -= kurasEnergi[pakai];
                        int uangAcak = penghasilan.Next(100, 201) * (pakai + 1);
                        uang += uangAcak;
                        hari++;
                        Console.WriteLine($"\nAnda menambang dengan {jenisBeliung[pakai]}!");
                    }
                    else { Console.WriteLine("\nEnergi tidak cukup!"); }
                    break;

                case 2:
                    if (uang >= 125)
                    {
                        uang -= 125;
                        potion++;
                        energi += 45;
                        if (energi > energiMax) energi = energiMax;
                        Console.WriteLine("\nEnergi bertambah dari Potion.");
                    }
                    else { Console.WriteLine("\nUang tidak cukup!"); }
                    break;

                case 3:
                    Console.WriteLine("\n1. Beliung Kayu\n2. Beliung Batu\n3. Beliung Besi\nPilihan: ");
                    int beliungPilihan;
                    while (!int.TryParse(Console.ReadLine(), out beliungPilihan) || beliungPilihan < 1 || beliungPilihan > 3)
                    {
                        Console.Write("Pilihan tidak valid. Masukkan angka 1, 2 atau 3: ");
                    }

                    switch (beliungPilihan)
                    {
                        case 1:
                            pakai = 0;
                            Console.WriteLine("Menggunakan Beliung Kayu.");
                            break;
                        case 2:
                            if (!beliungTerbeli[1])
                            {
                                if (uang >= hargaBeliung[1])
                                {
                                    uang -= hargaBeliung[1];
                                    beliungTerbeli[1] = true;
                                    pakai = 1;
                                    Console.WriteLine("Berhasil membeli Beliung Batu.");
                                }
                                else { Console.WriteLine("Uang kurang!"); }
                            }
                            else { pakai = 1; Console.WriteLine("Mengganti ke Beliung Batu."); }
                            break;
                        case 3:
                            if (!beliungTerbeli[2])
                            {
                                if (uang >= hargaBeliung[2])
                                {
                                    uang -= hargaBeliung[2];
                                    beliungTerbeli[2] = true;
                                    pakai = 2;
                                    Console.WriteLine("Berhasil membeli Beliung Besi.");
                                }
                                else { Console.WriteLine("Uang kurang!"); }
                            }
                            else { pakai = 2; Console.WriteLine("Mengganti ke Beliung Besi."); }
                            break;
                    }
                    break;

                case 4:
                    if (energi < energiMax)
                    {
                        energi = energiMax;
                        hari++;
                        Console.WriteLine("\nAnda tidur dan memulihkan energi.");
                    }
                    else { Console.WriteLine("\nEnergi sudah penuh!"); }
                    break;
            }

            Console.WriteLine("\nTekan Enter untuk lanjut...");
            Console.ReadKey();

            if (uang >= goal) sedangMenambang = false;
        }
        Console.WriteLine("TAMAT! Kamu mencapai target!");
    }
}