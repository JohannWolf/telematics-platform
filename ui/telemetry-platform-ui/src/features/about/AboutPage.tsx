import { Link } from 'react-router-dom';

export const AboutPage = () => {
  return (
    <div className="min-h-screen bg-gradient-to-br from-blue-50 to-indigo-100">
      <div className="container mx-auto px-4 py-12">
        <div className="mb-8">
          <Link to="/" className="text-indigo-600 hover:text-indigo-700">
            ← Back to Home
          </Link>
        </div>

        <div className="max-w-4xl mx-auto bg-white rounded-2xl shadow-xl p-8">
          <h1 className="text-3xl font-bold text-gray-900 mb-6">
            About Telemetry Platform
          </h1>
          
          <div className="space-y-6 text-gray-600">
            <p className="text-lg">
              Welcome to the Telemetry Platform - a comprehensive solution for monitoring and analyzing 
              your telemetry data in real-time.
            </p>

            <div className="border-l-4 border-indigo-500 pl-4 py-2 bg-indigo-50 rounded-r">
              <p className="italic">
                "Empowering organizations with actionable insights from their telemetry data"
              </p>
            </div>

            <div>
              <h2 className="text-xl font-semibold text-gray-900 mb-3">Features</h2>
              <ul className="list-disc list-inside space-y-2">
                <li>Real-time data visualization</li>
                <li>Customizable dashboards</li>
                <li>Advanced analytics and reporting</li>
                <li>Alert and notification system</li>
                <li>Historical data analysis</li>
                <li>Secure data storage with PostgreSQL</li>
              </ul>
            </div>

            <div>
              <h2 className="text-xl font-semibold text-gray-900 mb-3">Technology Stack</h2>
              <ul className="list-disc list-inside space-y-2">
                <li>Frontend: React with Vite, Tailwind CSS, Tremor</li>
                <li>Backend: C# ASP.NET Core</li>
                <li>Database: PostgreSQL</li>
                <li>Authentication: JWT-based authentication</li>
              </ul>
            </div>

            <div className="bg-gray-50 rounded-lg p-4 mt-6">
              <h3 className="font-semibold text-gray-900 mb-2">Contact Us</h3>
              <p>For support or inquiries, please contact us at:</p>
              <p className="text-indigo-600">support@telemetry-platform.com</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};