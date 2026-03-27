public class SkillService
{
    private readonly string _skillsPath;

    public SkillService()
    {
        _skillsPath = Path.Combine(Directory.GetCurrentDirectory(), "skills");
    }

    public string GetSkill(string skillFolderName)
    {
        var skillPath = Path.Combine(_skillsPath, skillFolderName, "SKILL.md");

        if (!File.Exists(skillPath))
            return string.Empty;

        return File.ReadAllText(skillPath);
    }

    public Dictionary<string, string> GetAllSkills()
    {
        var skills = new Dictionary<string, string>();

        if (!Directory.Exists(_skillsPath))
            return skills;

        var directories = Directory.GetDirectories(_skillsPath);

        foreach (var dir in directories)
        {
            var skillName = Path.GetFileName(dir);
            var skillFile = Path.Combine(dir, "SKILL.md");

            if (File.Exists(skillFile))
            {
                skills[skillName] = File.ReadAllText(skillFile);
            }
        }

        return skills;
    }
}