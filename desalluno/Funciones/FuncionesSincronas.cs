using System.Threading;

namespace desalluno.Funciones;

public static class FuncionesSincronas
{
    public static async Task<TimeSpan> HacerDesalluno(CancellationToken token)
    {
        Console.WriteLine("Haciendo el desayuno de manera sincrona");
        
        var startTime = DateTime.UtcNow.Ticks;
        await HacerCafe(token);
        await CalentarSarten(token);
        await TostarPan(token);
        await HacerZumo(token);
        var endTime = DateTime.UtcNow.Ticks;
        
        Console.WriteLine($"El desalluno esta listo. Tiempo total: {TimeSpan.FromTicks(endTime - startTime)}");
        return TimeSpan.FromTicks(endTime - startTime);
    }
    
    private static async Task HacerCafe(CancellationToken token)
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
        
        await FreirBacon(token);
        await FreirHuevo(token);
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
        await Task.Delay(300, token);
        var endTime = DateTime.UtcNow.Ticks;
        
        Console.WriteLine($"Bacon Frito. Tiempo total: {TimeSpan.FromTicks(endTime - startTime)}");
    }

    private static async Task TostarPan(CancellationToken token)
    {
        var startTime = DateTime.UtcNow.Ticks;
        await Task.Delay(200, token);
        var endTime = DateTime.UtcNow.Ticks;
        
        Console.WriteLine($"Pan Tostado. Tiempo total: {TimeSpan.FromTicks(endTime - startTime)}");
        
        await UntarMantequilla(token);
    }

    private static async Task UntarMantequilla(CancellationToken token)
    {
        var startTime = DateTime.UtcNow.Ticks;
        await Task.Delay(100, token);
        var endTime = DateTime.UtcNow.Ticks;
        
        Console.WriteLine($"Mermelada untada en el pan. Tiempo total: {TimeSpan.FromTicks(endTime - startTime)}");
    }

    private static async Task HacerZumo(CancellationToken token)
    {
        var startTime = DateTime.UtcNow.Ticks;
        await Task.Delay(200, token);
        var endTime = DateTime.UtcNow.Ticks;
        
        Console.WriteLine($"Zumo exprimido. Tiempo total: {TimeSpan.FromTicks(endTime - startTime)}");
    }
    
}