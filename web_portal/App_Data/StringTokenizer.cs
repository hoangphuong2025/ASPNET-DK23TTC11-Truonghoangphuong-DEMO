namespace web_portal.App_Data
{
    using System;

    public class StringTokenizer
    {
        private int currentPosition;
        private string delim;
        private bool delimsChanged;
        private char maxDelimChar;
        private int maxPosition;
        private int newPosition;
        private bool returnDelim;
        private string str;

        public StringTokenizer(string str) : this(str, " \t\n\r\f", false)
        {
        }

        public StringTokenizer(string str, string delim) : this(str, delim, false)
        {
        }

        public StringTokenizer(string str, string delim, bool returnDelim)
        {
            this.currentPosition = 0;
            this.newPosition = -1;
            this.str = str;
            this.delim = delim;
            this.returnDelim = returnDelim;
            this.maxPosition = str.Length;
            this.setMaxDelimChar();
            this.delimsChanged = false;
        }

        public int countTokens()
        {
            int num = 0;
            int currentPosition = this.currentPosition;
            while (currentPosition < this.maxPosition)
            {
                currentPosition = this.skipDelimiters(currentPosition);
                if (currentPosition >= this.maxPosition)
                {
                    return num;
                }
                currentPosition = this.scanToken(currentPosition);
                num++;
            }
            return num;
        }

        public bool hasMoreElements()
        {
            return this.hasMoreTokens();
        }

        public bool hasMoreTokens()
        {
            this.newPosition = this.skipDelimiters(this.currentPosition);
            return (this.newPosition < this.maxPosition);
        }

        public object nextElement()
        {
            return this.nextToken();
        }

        public string nextToken()
        {
            this.currentPosition = ((this.newPosition < 0) || this.delimsChanged) ? this.skipDelimiters(this.currentPosition) : this.newPosition;
            this.delimsChanged = false;
            this.newPosition = -1;
            if (this.currentPosition >= this.maxPosition)
            {
                throw new Exception("NoSuchElement");
            }
            int currentPosition = this.currentPosition;
            this.currentPosition = this.scanToken(this.currentPosition);
            return this.str.Substring(currentPosition, this.currentPosition - currentPosition);
        }

        public string nextToken(string s)
        {
            this.delim = s;
            this.delimsChanged = true;
            this.setMaxDelimChar();
            return this.nextToken();
        }

        private int scanToken(int i)
        {
            int num = i;
            while (num < this.maxPosition)
            {
                char ch = this.str[num];
                if ((ch <= this.maxDelimChar) && (this.delim.IndexOf(ch) >= 0))
                {
                    break;
                }
                num++;
            }
            if (this.returnDelim && (i == num))
            {
                char ch2 = this.str[num];
                if ((ch2 <= this.maxDelimChar) && (this.delim.IndexOf(ch2) >= 0))
                {
                    num++;
                }
            }
            return num;
        }

        private void setMaxDelimChar()
        {
            if (this.delim == null)
            {
                this.maxDelimChar = '\0';
            }
            else
            {
                char ch = '\0';
                for (int i = 0; i < this.delim.Length; i++)
                {
                    char ch2 = this.delim[i];
                    if (ch < ch2)
                    {
                        ch = ch2;
                    }
                }
                this.maxDelimChar = ch;
            }
        }

        private int skipDelimiters(int i)
        {
            if (this.delim == null)
            {
                throw new NullReferenceException();
            }
            int num = i;
            while (!this.returnDelim && (num < this.maxPosition))
            {
                char ch = this.str[num];
                if ((ch > this.maxDelimChar) || (this.delim.IndexOf(ch) < 0))
                {
                    return num;
                }
                num++;
            }
            return num;
        }
    }
}

