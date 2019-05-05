// import javax.xml.soap.Node;

// import org.w3c.dom.NodeList;

// public class MyVisitor implements NCU_PL_LexerVisitor 
// {
//     public Object visit(SimpleNode node, Object data)
//     {
//         if (node instanceof ASTNCU_PL_Program)
//         {
//             return visit((ASTNCU_PL_Program)node, data);
//         }
//         if (node instanceof ASTNCU_PL_Statement)
//         {
//             return visit((ASTNCU_PL_Statement)node, data);
//         }
//         if (node instanceof ASTSTATEMENT)
//         {
//             return visit((ASTSTATEMENT)node, data);
//         }
//         if (node instanceof ASTOUTPUT_STATEMENT)
//         {
//             return visit((ASTOUTPUT_STATEMENT)node, data);
//         }
//         if (node instanceof ASTINPUT_STATEMENT)
//         {
//             return visit((ASTINPUT_STATEMENT)node, data);
//         }
//         if (node instanceof ASTVARIABLE_DECLARATION)
//         {
//             return visit((ASTVARIABLE_DECLARATION)node, data);
//         }

//         if (node instanceof ASTVARIABLE_TYPE)
//         {
//             return visit((ASTVARIABLE_TYPE)node, data);
//         }
//         if (node instanceof ASTVARIABLE_DECLARATION)
//         {
//             return visit((ASTVARIABLE_DECLARATION)node, data);
//         }
//         if (node instanceof ASTVARIABLE_ASSIGNMENT)
//         {
//             return visit((ASTVARIABLE_ASSIGNMENT)node, data);
//         }
         
//         if (node instanceof ASTIF_THEN_STATEMENT)
//         {
//             return visit((ASTIF_THEN_STATEMENT)node, data);
//         }
//         if (node instanceof ASTEXPRESSION)
//         {
//             return visit((ASTEXPRESSION)node, data);
//         }
//         if (node instanceof ASTVARIABLE_ASSIGNMENT)
//         {
//             return visit((ASTVARIABLE_ASSIGNMENT)node, data);
//         }
        
//         if (node instanceof ASTIDENTIFIER_EXPRESSION)
//         {
//             return visit((ASTIDENTIFIER_EXPRESSION)node, data);
//         }
//         if (node instanceof ASTLITERAL_VALUE_EXPRESSION )
//         {
//             return visit((ASTLITERAL_VALUE_EXPRESSION)node, data);
//         }
//         if (node instanceof ASTPARENTHESIZED_EXPRESSION)
//         {
//             return visit((ASTPARENTHESIZED_EXPRESSION)node, data);
//         }
        
//         if (node instanceof ASTPARENTHESIZED_EXPRESSION)
//         {
//             return visit((ASTPARENTHESIZED_EXPRESSION)node, data);
//         }
//         if (node instanceof ASTBINARY_EXPRESSION )
//         {
//             return visit((ASTBINARY_EXPRESSION)node, data);
//         }
//         if (node instanceof ASTBINARY_OPERATOR)
//         {
//             return visit((ASTBINARY_OPERATOR)node, data);
//         }
         
//         System.out.println("Called visit(SimpleNode)");
//         return null;
//     }
//     public Object visit(ASTNCU_PL_Program node, Object data)
//     {
//         System.out.println("Called visit(ASTNCU_PL_Program)");
//         walkTree(node, data);
//         return null;
//     }
//     public Object visit(ASTNCU_PL_Statement node, Object data)
//     {
//         System.out.println("Called visit(ASTNCU_PL_Statement)");
//         walkTree(node, data);
//         return null;
//     }
//     public Object visit(ASTSTATEMENT node, Object data)
//     {
//         System.out.println("Called visit(ASTSTATEMENT)");
//         walkTree(node, data);
//         return null;
//     }
//     public Object visit(ASTOUTPUT_STATEMENT node, Object data)
//     {
//         System.out.println("Called visit(ASTOUTPUT_STATEMENT)");
//         walkTree(node, data);
//         return null;
//     }
//     public Object visit(ASTINPUT_STATEMENT node, Object data)
//     {
//         System.out.println("Called visit(ASTINPUT_STATEMENT)");
//         walkTree(node, data);
//         return null;
//     }
//     public Object visit(ASTVARIABLE_DECLARATION node, Object data)
//     {
//         System.out.println("Called visit(ASTVARIABLE_DECLARATION)");
//         walkTree(node, data);
//         return null;
//     }
//     public Object visit(ASTVARIABLE_TYPE node, Object data)
//     {
//         System.out.println("Called visit(ASTVARIABLE_TYPE)");
//         return null;
//     }
//     public Object visit(ASTVARIABLE_ASSIGNMENT node, Object data)
//     {
//         System.out.println("Called visit(ASTVARIABLE_ASSIGNMENT)");
//         return null;
//     }
//     public Object visit(ASTIF_THEN_STATEMENT node, Object data)
//     {
//         System.out.println("Called visit(ASTIF_THEN_STATEMENT)");
//         return null;
//     }
//     public Object visit(ASTEXPRESSION node, Object data)
//     {
//         System.out.println("Called visit(ASTEXPRESSION)");
//         return null;
//     }
//     public Object visit(ASTIDENTIFIER_EXPRESSION node, Object data)
//     {
//         System.out.println("Called visit(ASTIDENTIFIER_EXPRESSION)");
//         return null;
//     }
//     public Object visit(ASTLITERAL_VALUE_EXPRESSION node, Object data)
//     {
//         System.out.println("Called visit(ASTLITERAL_VALUE_EXPRESSION)");
//         return null;
//     }
//     public Object visit(ASTPARENTHESIZED_EXPRESSION node, Object data)
//     {
//         System.out.println("Called visit(ASTPARENTHESIZED_EXPRESSION)");
//         return null;
//     }
//     public Object visit(ASTBINARY_EXPRESSION node, Object data)
//     {
//         System.out.println("Called visit(ASTBINARY_EXPRESSION)");
//         return null;
//     }
//     public Object visit(ASTBINARY_OPERATOR node, Object data)
//     {
//         System.out.println("Called visit(ASTBINARY_OPERATOR)");
//         return null;
//     }

//     public Object visit(ASTDeclareString node,Object data)
//     {
//         return null;
//     }

//     public Object visit(ASTDeclareInt node,Object data)
//     {
//         return null;
//     }

//     public Object visit(ASTDeclareBool node,Object data)
//     {
//         return null;
//     }

//     public void walkTree(SimpleNode parent, Object data)
//     {
//         for(int i=0; i<parent.jjtGetNumChildren(); i++)
//         {
//             SimpleNode child = (SimpleNode)parent.jjtGetChild(i);
//             visit(child, data);
//             walkTree(child, data);
//         }
//     }
// }
  