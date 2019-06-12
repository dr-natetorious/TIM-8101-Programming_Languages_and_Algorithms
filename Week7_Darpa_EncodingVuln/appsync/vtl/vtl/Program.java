package vtl;
import java.io.StringWriter;
import org.apache.velocity.VelocityContext;
import org.apache.velocity.Template;
import org.apache.velocity.app.Velocity;
import org.apache.velocity.exception.ResourceNotFoundException;
import org.apache.velocity.exception.ParseErrorException;
import org.apache.velocity.exception.MethodInvocationException;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class Program {

	public static void main(String[] args) {
		
		Logger logger = LoggerFactory.getLogger(Program.class);
	    logger.info("Hello World");
		
		Velocity.init();

		VelocityContext context = new VelocityContext();

		context.put( "name", new String("Velocity") );

		Template template = null;

		try
		{
		  template = Velocity.getTemplate("Template.vm");
		}
		catch( ResourceNotFoundException rnfe )
		{
		  System.out.println("Unable to find Resource");
		}
		catch( ParseErrorException pee )
		{
		  System.out.println("Unable to parse file");
		}
		catch( MethodInvocationException mie )
		{
			System.out.println("Unable to invoke method");
		}
		catch( Exception e )
		{
			System.out.println("Unhandled Exception");
		}

		StringWriter sw = new StringWriter();
		template.merge( context, sw );
		
		System.out.println("===============");
		System.out.println("MERGED TEMPLATE");
		System.out.println("===============");
		System.out.println();
		System.out.println(sw.toString());
	}

}
