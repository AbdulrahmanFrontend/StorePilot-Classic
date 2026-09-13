using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace StorePilot.WinForms.Foundation;

/// <summary>
/// Persists the small amount of branding information needed by the shell.
///
/// Why XML here?
/// - Works directly with .NET Framework 4.8.
/// - No database is required just to start the application.
/// - Easy to replace later with a database-backed settings service.
/// </summary>
public sealed class AppBrandSettingsStore
{
    private readonly string _root = Path.Combine(
        Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData),
        "StorePilot");

    private string SettingsFile => Path.Combine(
        _root, 
        "Settings",
        "brand-settings.json");

    private string Branding => Path.Combine(_root, "Branding");

    public AppBrandSettingsStore() 
    {
        Directory.CreateDirectory(Path.GetDirectoryName(SettingsFile)!);
        Directory.CreateDirectory(Branding);
    }

    public AppBrandSettings Load() 
    { 
        try 
        { 
            if (!File.Exists(SettingsFile))
                return new(); 

            return JsonSerializer
                .Deserialize<AppBrandSettings>(File.ReadAllText(SettingsFile))
                ?? new();
        } 
        catch
        { 
            return new();
        } 
    }

    public void Save(AppBrandSettings s)
    {
        File.WriteAllText(
            SettingsFile,
            JsonSerializer.Serialize(
                s, 
                new JsonSerializerOptions
                { 
                    WriteIndented = true
                }));
    }

    public string? CopyLogo(string source) 
    { 
        if 
            (!File.Exists(source))
            return null;
        
        foreach (var f in Directory.GetFiles(Branding, "logo.*"))
        { 
            try
            { 
                File.Delete(f);
            } 
            catch 
            { 

            } 
        } 

        var target = Path.Combine(Branding, "logo" + Path.GetExtension(source));
        File.Copy(source, target, true);
        return target; 
    }

    public void DeleteLogo()
    { 
        foreach (var f in Directory.GetFiles(Branding, "logo.*"))
        { 
            try 
            { 
                File.Delete(f);
            }
            catch
            { 

            } 
        }
    }
}