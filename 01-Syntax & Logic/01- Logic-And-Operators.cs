/*
 * =======================================================================
 * PROJECT  : CSharp-Learning-Journey
 * TOPIC    : Logicals & Modulus Operators
 * MODULE   : 01-Basics
 * AUTHOR   : Kyuuuzo
 * DATE     : 12 Maret 2026
 * * DESCRIPTION:
 * Implementasi logika modulus untuk sistem konversi mata uang (Perak, 
 * Silver, Platinum) dan pengecekan gerbang logika untuk kondisi 
 * ekonomi serta beban muatan karakter.
 * =======================================================================
 */

using System;

class Program
{
    static void Main(string[] args)
    {
        int kapasitasKoin = 50;

        int koinPerak = 12345;
        int sisaPerak = koinPerak % 120;
        int koinSilver = koinPerak / 120;
        int sisaSilver = koinSilver % 15;
        int koinPlatinum = koinSilver / 15;
        int jumlahKoin = sisaPerak + sisaSilver + koinPlatinum;

        Console.WriteLine("--==--==-- Perhitungan Koin Sebelum Konversi --==--==--");
        Console.WriteLine($"Jumlah koin yang dimiliki: {jumlahKoin}");
        Console.WriteLine($"Termasuk: {sisaPerak} Perak, {sisaSilver} Silver dan {koinPlatinum} Platinum");

        int hargaKuda = 380000;
        bool apaCukup = koinPerak >= hargaKuda;
        bool apaKeberatan = jumlahKoin > kapasitasKoin;

        if (apaCukup && apaKeberatan)
        {
            Console.WriteLine("Kamu terlalu berat!");
        }
        else if (apaCukup && !apaKeberatan)
        {
            Console.WriteLine("Kuda berhasil dibeli!");
            int sisaKoin = koinPerak - hargaKuda;
            int koinPerakBaru = sisaKoin;
            int sisaKoinPerakBaru = koinPerakBaru % 120;
            int koinSilverBaru = koinPerakBaru / 120;
            int sisaKoinSilverBaru = koinSilverBaru % 15;
            int koinPlatinumBaru = koinSilverBaru / 15; 
        }
        return;
    }
}