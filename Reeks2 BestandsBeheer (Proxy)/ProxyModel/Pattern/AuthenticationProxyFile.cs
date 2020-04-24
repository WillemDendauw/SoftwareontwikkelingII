using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyModel.Pattern
{
    public class AuthenticationProxyFile : IFile
    {
        private User user;
        private string filename;
        private IFile file;

        public AuthenticationProxyFile(User user, string filename)
        {
            this.user = user;
            this.filename = filename;
        }

        public string Content
        {
            get
            {
                if (filename.StartsWith("."))
                {
                    if (!user.IsAdmin)
                    {
                        throw new FileAccesException("User '" + user.UserName + "' has no acces to this file");
                    }
                }
                if (file == null)
                {
                    file = new CachingProxyFile(filename);
                }
                return file.Content;
            }
        }
    }
}
