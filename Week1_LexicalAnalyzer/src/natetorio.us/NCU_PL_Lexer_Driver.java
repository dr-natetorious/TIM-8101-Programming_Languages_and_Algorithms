/**
 * Northcentral University
 * School of Business & Technology Management
 * Lexer driver for NCU/PL
 */

public class NCU_PL_Lexer_Driver 
{
   
    public static void main(String [] args) 
        throws java.io.IOException, ParseException
    {
        try
        {
            System.out.println("Beginning lexical analysis of file \"" + args[0] + "\"");
            NCU_PL_Lexer lexer = new NCU_PL_Lexer(new java.io.FileInputStream(args[0]));
            
            SimpleNode root = lexer.NCU_PL_Program();
            root.dump(">> ");
            // MyVisitor visitor = new MyVisitor();
            // root.jjtAccept(visitor, "tacos-are-good");

            // for(int i=0; i<root.children.length; i++)
            // {
            //     visitor.visit((SimpleNode)root.jjtGetChild(i), "burrito");
            // }

            lexer.ReInit(new java.io.FileInputStream(args[0]));
            boolean EOF = false;
            while(!EOF)
            {
                Token token = lexer.token_source.getNextToken();
                String tokenKind = NCU_PL_LexerConstants.tokenImage[token.kind];
                System.out.print
                (
                    "Token: " + tokenKind + 
                    "\n\tLine: " + token.beginLine + 
                    "\n\tColumn: " + token.beginColumn
                );

                if(tokenKind.equals("<INTEGER_LITERAL>") || tokenKind.equals("<IDENTIFIER>"))
                {
                    System.out.print("\n\tValue: " + token.image);
                }
                System.out.println();
                EOF = (NCU_PL_LexerConstants.tokenImage[token.kind].equals("<EOF>"));
            }
            System.out.println("Lexical analysis successfull");
        }
        catch(ParseException ex)
        {
            System.out.println("Error parsing input: ");
            System.out.println(ex.getMessage());
            throw ex;
        }
        catch(TokenMgrError ex)
        {
            System.out.println("Error parsing input: ");
            System.out.println(ex.getMessage());
        }
    }
}

