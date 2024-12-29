using System;
using System.IO;
using AuroraLib.Compression;
using AuroraLib.Compression.Algorithms;
using AuroraLib.Compression.Interfaces;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 4)
        {
            Console.WriteLine("Usage: AuroraLibCompression-cli -c|-d <algorithm> <inputFile> <outputFile>");
            return;
        }

        string operation = args[0];
        string algorithm = args[1];
        string inputFilePath = args[2];
        string outputFilePath = args[3];

        try
        {
            using FileStream source = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using FileStream destination = new FileStream(outputFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.None);

            ICompressionAlgorithm compressionAlgorithm = algorithm.ToLower() switch
            {
                "lz10" => new LZ10(),
                "lz11" => new LZ11(),
                "lz40" => new LZ40(),
                "lz60" => new LZ60(),
                "lz77" => new LZ77(),
                "mio0" => new MIO0(),
                "yay0" => new Yay0(),
                "yaz0" => new Yaz0(),
                "yaz1" => new Yaz1(),
                "huf20" => new HUF20(),
                "rle30" => new RLE30(),
                "lzon" => new LZOn(),
                "hwgz" => new HWGZ(),
                "prs" => new PRS(),
                "lzsega" => new LZSega(),
                "cnx2" => new CNX2(),
                "comp" => new COMP(),
                "cxlz" => new CXLZ(),
                "lz00" => new LZ00(),
                "lz01" => new LZ01(),
                "aklz" => new AKLZ(),
                "cns" => new CNS(),
                "clz0" => new CLZ0(),
                "fcmp" => new FCMP(),
                "gclz" => new GCLZ(),
                "lz02" => new LZ02(),
                "lzhudson" => new LZHudson(),
                "rlhudson" => new RLHudson(),
                "lzshrek" => new LZShrek(),
                "lzss" => new LZSS(),
                "refpack" => new RefPack(),
                "gzip" => new GZip(),
                "zlib" => new ZLib(),
                "asurazlb" => new AsuraZlb(),
                "zlb" => new ZLB(),
                "allz" => new ALLZ(),
                "lzo" => new LZO(),
                "lz4" => new LZ4(),
                "mdf0" => new MDF0(),
                "level5" => new Level5(),
                "sszl" => new SSZL(),
                "iecp" => new IECP(),
                _ => throw new ArgumentException("Unsupported algorithm. Supported algorithms: LZ10, LZ11, LZ40, LZ60, LZ77, MIO0, Yay0, Yaz0, Yaz1, HUF20, RLE30, LZOn, HWGZ, PRS, LZSega, CNX2, COMP, CXLZ, LZ00, LZ01, AKLZ, CNS, CLZ0, FCMP, GCLZ, LZ02, LZHudson, RLHudson, LZShrek, LZSS, RefPack, GZip, ZLib, AsuraZlb, ZLB, ALLZ, LZO, LZ4, MDF0, Level5, SSZL, IECP")
            };

            if (operation.Equals("-c", StringComparison.OrdinalIgnoreCase))
            {
                compressionAlgorithm.Compress(source, destination);
                Console.WriteLine("Compression completed.");
            }
            else if (operation.Equals("-d", StringComparison.OrdinalIgnoreCase))
            {
                compressionAlgorithm.Decompress(source, destination);
                Console.WriteLine("Decompression completed.");
            }
            else
            {
                Console.WriteLine("Invalid argument. Use '-c' for compression or '-d' for decompression.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
