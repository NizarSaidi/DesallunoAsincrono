using System;
using System.Threading;
using System.Threading.Tasks;

namespace desalluno.Funciones;

public static class FuncionesMasOptimas
{
    public static async Task<TimeSpan> HacerDesallunoOptimo(CancellationToken token)
    {
        Console.WriteLine("Haciendo el desayuno de la manera más optima");
        
        var startTime = DateTime.UtcNow.Ticks;
        var task1 = Task.Run(() => HacerCafe(token));
        var task2 = Task.Run(() => CalentarSarten(token));
        var task3 = Task.Run(() => TostarPan(token));
        var task4 = Task.Run(() => HacerZumo(token));
        await Task.WhenAll(task1, task2, task3, task4);
        var endTime = DateTime.UtcNow.Ticks;
        
        Console.WriteLine($"El desalluno esta listo. Tiempo total: {TimeSpan.FromTicks(endTime - startTime)}");
        return TimeSpan.FromTicks(endTime - startTime);
    }
    
    private static async  Task HacerCafe(CancellationToken token)
    {
        var startTime = DateTime.UtcNow.Ticks;
        await Task.Delay(200, token);
        var endTime = DateTime.UtcNow.Ticks;
        
        Console.WriteLine($"Cafe Hecho Tiempo total: {TimeSpan.FromTicks(endTime - startTime)}");
    }
    private static async Task CalentarSarten(CancellationToken token)
    {
        var startTime = DateTime.UtcNow.Ticks;
        await Task.Delay(200, token);
        var endTime = DateTime.UtcNow.Ticks;
        
        Console.WriteLine($"Sarten Caliente. Tiempo total: {TimeSpan.FromTicks(endTime - startTime)}");
        
        var task1 = Task.Run(() => FreirHuevo(token));
        var task2 = Task.Run(() => FreirBacon(token)); 
        await Task.WhenAll(task1, task2);
    }

    private static async Task FreirHuevo(CancellationToken token)
    {
        var startTime = DateTime.UtcNow.Ticks;
        await Task.Delay(300, token);
        var endTime = DateTime.UtcNow.Ticks;
        
        Console.WriteLine($"Huevo Frito. Tiempo total: {TimeSpan.FromTicks(endTime - startTime)}");
    }

    private static async Task FreirBacon(CancellationToken token)
    {
        var startTime = DateTime.UtcNow.Ticks;
        Thread.Sleep(300);
        var endTime = DateTime.UtcNow.Ticks;
        
        Console.WriteLine($"Bacon Frito. Tiempo total: {TimeSpan.FromTicks(endTime - startTime)}");
    }

    private static async Task TostarPan(CancellationToken token)
    {
        var startTime = DateTime.UtcNow.Ticks;
        Thread.Sleep(200);
        var endTime = DateTime.UtcNow.Ticks;
        
        Console.WriteLine($"Pan Tostado. Tiempo total: {TimeSpan.FromTicks(endTime - startTime)}");
        
        await UntarMantequilla(token);
    }

    private static async Task UntarMantequilla(CancellationToken token)
    {
        var startTime = DateTime.UtcNow.Ticks;
        Thread.Sleep(100);
        var endTime = DateTime.UtcNow.Ticks;
        
        Console.WriteLine($"Mermelada untada en el pan. Tiempo total: {TimeSpan.FromTicks(endTime - startTime)}");
    }

    private static async Task HacerZumo(CancellationToken token)
    {
        var startTime = DateTime.UtcNow.Ticks;
        Thread.Sleep(200);
        var endTime = DateTime.UtcNow.Ticks;
        
        Console.WriteLine($"Zumo exprimido. Tiempo total: {TimeSpan.FromTicks(endTime - startTime)}");
    }
}