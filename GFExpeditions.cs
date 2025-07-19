using System;
using System.Collections.Generic;
using System.Linq;

public class CombinationFinder
{
    public static Tuple<double, List<double[]>> FindBestCombination(List<double[]> data, double[] ratios)
    {
        double bestScore = -double.MaxValue;
        List<double[]> bestCombinationElements = new List<double[]>();
        foreach (var indicesCombination in GetCombinations(Enumerable.Range(0, data.Count).ToList(), 4))
        {
            double currentRa = 0;
            double currentRb = 0;
            double currentRc = 0;
            double currentRd = 0;
            foreach (int index in indicesCombination)
            {
                currentRa += data[index][0];
                currentRb += data[index][1];
                currentRc += data[index][2];
                currentRd += data[index][3];
            }
            double currentScore = (ratios[0] * currentRa) +
                                  (ratios[1] * currentRb) +
                                  (ratios[2] * currentRc) +
                                  (ratios[3] * currentRd);
            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                bestCombinationElements = indicesCombination.Select(i => data[i]).ToList();
            }
        }

        return Tuple.Create(bestScore, bestCombinationElements);
    }
    public static IEnumerable<IEnumerable<T>> GetCombinations<T>(List<T> list, int k)
    {
        if (k == 0)
        {
            yield return new T[0];
        }
        else if (list.Count == 0)
        {
            yield break;
        }
        else if (k > list.Count)
        {
            yield break;
        }
        else
        {
            T head = list[0];
            List<T> tail = list.Skip(1).ToList();

            foreach (var combination in GetCombinations(tail, k - 1))
            {
                yield return new List<T>(combination.Prepend(head));
            }
            foreach (var combination in GetCombinations(tail, k))
            {
                yield return new List<T>(combination);
            }
        }
    }


    public static void Main(string[] args)
    {
        List<double[]> rawData = new List<double[]>
        {
            new double[] {0, 186, 186, 0, 1}, new double[] {196, 0, 0, 124.7, 2}, new double[] {80.3, 80.3, 80.3, 22.3, 3}, new double[] {0, 53.5, 35.7, 33.4, 4},
            new double[] {40, 128, 64, 0, 11}, new double[] {0, 84, 128, 0, 12}, new double[] {32, 0, 32, 10, 13}, new double[] {85.5, 85.5, 0, 0, 14},
            new double[] {160.5, 0, 0, 48, 21}, new double[] {42.7, 142.7, 56.7, 0, 22}, new double[] {2.5, 2.5, 2.5, 61.5, 23}, new double[] {0, 44.5, 107, 10.7, 24},
            new double[] {159, 0, 240, 0, 31}, new double[] {0, 170.7, 98.7, 42.7, 32}, new double[] {0, 214, 0, 0, 33}, new double[] {0, 0, 64.2, 64.2, 34},
            new double[] {0, 197, 197, 0, 41}, new double[] {0, 0, 0, 112, 42}, new double[] {142.7, 98, 0, 0, 43}, new double[] {53.5, 53.5, 53.5, 20, 44},
            new double[] {0, 0, 214, 96, 51}, new double[] {0, 256.8, 128.4, 0, 52}, new double[] {214, 107, 107, 0, 53}, new double[] {15.3, 0, 0, 107, 54},
            new double[] {160.5, 160.5, 0, 53.5, 61}, new double[] {0, 71.3, 196, 35.7, 62}, new double[] {0, 0, 42.8, 107, 63}, new double[] {71.3, 71.3, 71.3, 0, 64},
            new double[] {278, 0, 278, 0, 71}, new double[] {0, 173.8, 0, 80.3, 72}, new double[] {175.1, 116.7, 116.7, 0, 73}, new double[] {33.4, 33.4, 33.4, 80.3, 74},
            new double[] {160, 160, 160, 0, 81}, new double[] {0, 0, 0, 160.3, 82}, new double[] {53.5, 107, 107, 0, 83}, new double[] {178.3, 47.6, 47.6, 11.9, 84},
            new double[] {0, 0, 214, 106, 91}, new double[] {128, 0, 128, 71.3, 92}, new double[] {178.2, 178.2, 0, 0, 93}, new double[] {76.4, 137.6, 137.6, 0, 94},
            new double[] {223.5, 321, 0, 0, 101}, new double[] {0, 153.6, 115.2, 0, 102}, new double[] {0, 96.2, 96.2, 60.2, 103}, new double[] {70.6, 70.6, 70.6, 35.3, 104},
            new double[] {93.5, 280.8, 0, 0, 111}, new double[] {96.3, 144.3, 144.3, 0, 112}, new double[] {0, 100.3, 200.6, 33.4, 113}, new double[] {0, 176.5, 0, 96.3, 114},
            new double[] {0, 235, 235, 0, 121}, new double[] {256.7, 0, 0, 85.3, 122}, new double[] {95.1, 142.7, 142.7, 0, 123}, new double[] {160.5, 0, 160.5, 0, 124},
            new double[] {0, 0, 428, 0, 131}, new double[] {142.7, 142.7, 142.7, 53.5, 132}, new double[] {0, 178.3, 0, 53.5, 133}, new double[] {0, 0, 0, 178.3, 134}
        };

        Console.WriteLine("请依次输入您的 人力:弹药:口粮:零件 现有数值，如果大于30w，请输入0");
        double aRatioInput, bRatioInput, cRatioInput, dRatioInput;

        try
        {
            Console.Write("请输入 人力 的值: ");
            aRatioInput = double.Parse(Console.ReadLine());
            Console.Write("请输入 弹药 的值: ");
            bRatioInput = double.Parse(Console.ReadLine());
            Console.Write("请输入 口粮 的值: ");
            cRatioInput = double.Parse(Console.ReadLine());
            Console.Write("请输入 零件 的值: ");
            dRatioInput = double.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("栽种你输入的是数字吗？");
            return;
        }

        double aRatio = 300000 - aRatioInput;
        double bRatio = 300000 - bRatioInput;
        double cRatio = 300000 - cRatioInput;
        double dRatio = 300000 - dRatioInput;

        double[] inputRatios = { aRatio, bRatio, cRatio, dRatio };

        Console.WriteLine("\n正在计算最优组合，请稍候...");
        Tuple<double, List<double[]>> result = FindBestCombination(rawData, inputRatios);

        double bestScoreResult = result.Item1;
        List<double[]> bestElements = result.Item2;

        Console.WriteLine("\n--- 计算结果 ---");
        Console.WriteLine($"在您提供的比例 {aRatio}:{bRatio}:{cRatio}:{dRatio} 下，找到的最优加权分数是: {bestScoreResult:F2}");

        Console.WriteLine("\n以下是构成最优组合的四个数组（[人力, 弹药, 口粮, 零件, 编号]）：");
        foreach (var element in bestElements)
        {
            Console.WriteLine($"[{string.Join(", ", element)}]");
        }

        double finalRa = bestElements.Sum(e => e[0]);
        double finalRb = bestElements.Sum(e => e[1]);
        double finalRc = bestElements.Sum(e => e[2]);
        double finalRd = bestElements.Sum(e => e[3]);

        double totalSum = finalRa + finalRb + finalRc + finalRd;
        if (totalSum > 0)
        {
            Console.WriteLine($"\n该组合的实际比例近似为:");
            Console.WriteLine($"  人力: {finalRa / totalSum:F2}");
            Console.WriteLine($"  弹药: {finalRb / totalSum:F2}");
            Console.WriteLine($"  口粮: {finalRc / totalSum:F2}");
            Console.WriteLine($"  零件: {finalRd / totalSum:F2}");
        }
        else
        {
            Console.WriteLine("\n栽种好好输");
        }
        Console.WriteLine("\n按任意键退出...");
        Console.ReadKey();
    }
}
