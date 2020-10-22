using System.Threading;
using System.Threading.Tasks;

namespace Emailer.Templates
{
    public interface ITemplateEngine
    {
        Task<string> MergeTemplate(Template template, Customer customer, EmailRecipient recipient,
            CancellationToken cancellationToken = default);
    }
}