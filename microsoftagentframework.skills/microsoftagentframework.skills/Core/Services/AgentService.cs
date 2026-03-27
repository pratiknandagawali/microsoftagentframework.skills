public class AgentService
{
    private readonly FoundryLLMService _llm;
    private readonly SkillService _skills;

    public AgentService(FoundryLLMService llm, SkillService skills)
    {
        _llm = llm;
        _skills = skills;
    }

    public async Task<string> Ask(string query)
    {
        var selectedSkills = new List<string>();
        var lowerQuery = query.ToLower();

        if (lowerQuery.Contains("expense") || lowerQuery.Contains("taxi"))
        {
            selectedSkills.Add(_skills.GetSkill("expense-report"));
        }

        if (lowerQuery.Contains("leave") || lowerQuery.Contains("policy"))
        {
            selectedSkills.Add(_skills.GetSkill("leave-policy"));
        }

        if (lowerQuery.Contains("total") || lowerQuery.Contains("average"))
        {
            selectedSkills.Add(_skills.GetSkill("data-analysis"));
        }

        if (lowerQuery.Contains("summarize") || query.Length > 200)
        {
            selectedSkills.Add(_skills.GetSkill("document-summarizer"));
        }

        if (!selectedSkills.Any())
        {
            return await _llm.Ask(query);
        }

        var combinedSkills = string.Join("\n\n---\n\n", selectedSkills);

        var finalPrompt = $"""
        You are an intelligent assistant.

        You have access to the following skills:

        ------------------------
        {combinedSkills}
        ------------------------

        Carefully read the skills and follow:
        - "When to use"
        - "Rules"
        - "Examples"

        User Question:
        {query}

        Instructions:
        - Use only relevant rules
        - Be precise
        - Do not hallucinate
        """;

        return await _llm.Ask(finalPrompt);
    }
}