import { useAuthStore } from '../../core/store/useAuthStore';
import { useNavigate } from 'react-router-dom';

export const DashboardPage = () => {
  const { user, logout } = useAuthStore();
  const navigate = useNavigate();

  const handleLogout = async () => {
    await logout();
    navigate('/login');
  };

  return (
    <div className="min-h-screen bg-gray-50">
      <nav className="bg-white shadow-sm">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="flex justify-between h-16">
            <div className="flex items-center">
              <h1 className="text-xl font-semibold text-gray-900">Telemetry Dashboard</h1>
            </div>
            <div className="flex items-center space-x-4">
              <span className="text-sm text-gray-600">Welcome, {user?.name || user?.email}</span>
              <button
                onClick={handleLogout}
                className="px-4 py-2 text-sm font-medium text-white bg-red-600 rounded-md hover:bg-red-700"
              >
                Logout
              </button>
            </div>
          </div>
        </div>
      </nav>

      <div className="max-w-7xl mx-auto py-6 sm:px-6 lg:px-8">
        <div className="px-4 py-6 sm:px-0">
          <div className="border-4 border-dashed border-gray-200 rounded-lg p-4">
            <h2 className="text-2xl font-bold text-gray-900 mb-4">Your Telemetry Data</h2>
            <p className="text-gray-600">
              This is your protected dashboard. Add your Tremor charts and telemetry visualizations here.
            </p>
            
            {/* Example Tremor component placeholder */}
            <div className="mt-6 grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
              <div className="bg-white p-4 rounded-lg shadow">
                <h3 className="font-semibold">Active Sensors</h3>
                <p className="text-2xl font-bold text-indigo-600">24</p>
              </div>
              <div className="bg-white p-4 rounded-lg shadow">
                <h3 className="font-semibold">Data Points Today</h3>
                <p className="text-2xl font-bold text-indigo-600">1,234</p>
              </div>
              <div className="bg-white p-4 rounded-lg shadow">
                <h3 className="font-semibold">Active Alerts</h3>
                <p className="text-2xl font-bold text-yellow-600">3</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};