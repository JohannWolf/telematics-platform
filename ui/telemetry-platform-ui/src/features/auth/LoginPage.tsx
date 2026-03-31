import { Link } from 'react-router-dom';
import { LoginForm } from './components/LoginForm';

export const LoginPage = () => {
  return (
    <div className="min-h-screen bg-gradient-to-br from-blue-50 to-indigo-100 flex items-center justify-center p-4">
      <div className="max-w-md w-full space-y-8 bg-white rounded-2xl shadow-xl p-8">
        {/* Logo/Header */}
        <div className="text-center">
          <div className="mx-auto h-12 w-12 bg-indigo-600 rounded-xl flex items-center justify-center">
            <svg className="h-6 w-6 text-white" fill="none" viewBox="0 0 24 24" stroke="currentColor">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M9 19v-6a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2a2 2 0 002-2zm0 0V9a2 2 0 012-2h2a2 2 0 012 2v10m-6 0a2 2 0 002 2h2a2 2 0 002-2m0 0V5a2 2 0 012-2h2a2 2 0 012 2v14a2 2 0 01-2 2h-2a2 2 0 01-2-2z" />
            </svg>
          </div>
          <h2 className="mt-6 text-3xl font-bold text-gray-900">
            Telemetry Platform
          </h2>
          <p className="mt-2 text-sm text-gray-600">
            Sign in to access your telemetry data
          </p>
        </div>

        <LoginForm />

        <div className="text-center">
          <Link to="/about" className="text-sm text-indigo-600 hover:text-indigo-500">
            About this platform
          </Link>
        </div>
      </div>
    </div>
  );
};