/*
 * =======================================================================
 * PROJECT  : CSharp-Learning-Journey
 * TOPIC    : Control Flow (Loops, Switch-Case, & Conditionals)
 * MODULE   : 02-Control-Flow
 * AUTHOR   : Kyuuuzo
 * DATE     : 13 Maret 2026
 * * DESCRIPTION:
 * Implementasi alur kontrol program menggunakan perulangan (While Loop) 
 * dan percabangan (If-Else & Switch-Case) dalam bentuk simulasi 
 * pertarungan mini RPG (Turn-Based) antara Pemain dan Boss. 
 * Termasuk penanganan input (TryParse) untuk mencegah error/crash.
 * =======================================================================
 */

using System;

class Program
{
    static void Main(string[] args)
    {
        int healthPemain = 120;
        int maxHealthPemain = 120;
        int healthBoss = 2000;
        int jumlahPotion = 3;

        int damagePemain = 120;
        int damageBoss = 20;

        while (healthPemain > 0 && healthBoss > 0)
        {
            Console.Clear();
            Console.WriteLine("=--=--=--=--= Giliran =--=--=--=--=--\n" +
                "Giliran Pemain!\n" +
                "1. Menyerang\n" +
                "2. Minum Potion.\n" +
                $"Sisa Potion: {jumlahPotion}\n" +
                "=--=--=--=--= || =--=--=--=--=\n\n" +
                $"Darah Pemain = {healthPemain}\n" +
                $"Darah Boss = {healthBoss}");

            int pilihan;
            while (!int.TryParse(Console.ReadLine(), out pilihan) || (pilihan != 1 && pilihan != 2))
            {
                Console.WriteLine("Input tidak valid! Masukkan (1/2)!: ");
            }

            switch (pilihan)
            {
                case 1:
                    healthBoss -= damagePemain;
                    Console.WriteLine($"\nAnda menyerang Boss dan memberikan {damagePemain} damage!");
                    break;
                case 2:
                    if (jumlahPotion > 0 && healthPemain < maxHealthPemain)
                    {
                        healthPemain += 65;
                        if (healthPemain > maxHealthPemain) healthPemain = maxHealthPemain;
                        jumlahPotion--;
                        Console.WriteLine($"\nPotion Diminum. Darah sekarang: {healthPemain}.");
                    }
                    else if (jumlahPotion == 0)
                    {
                        Console.WriteLine("\nPotion Habis!");
                    }
                    else
                    {
                        Console.WriteLine("\nDarah masih penuh!");
                    }
                    break;
            }

            if (healthBoss > 0)
            {
                healthPemain -= damageBoss;
                Console.WriteLine($"Boss menyerang Anda dan memberikan {damageBoss} damage!");
            }

            Console.WriteLine("\nTekan Enter untuk lanjut ke giliran berikutnya...");
            Console.ReadKey();
        }

        Console.Clear();
        if (healthBoss <= 0) Console.WriteLine("SELAMAT! Boss berhasil dikalahkan!");
        else Console.WriteLine("GAME OVER. Anda telah dikalahkan oleh Boss.");

        Console.WriteLine("\nPermainan Selesai.");
    }
}