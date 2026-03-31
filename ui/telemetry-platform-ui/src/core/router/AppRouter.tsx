import { Routes, Route, Navigate } from 'react-router-dom';
import { ProtectedRoute } from './ProtectedRoute';
import { LoginPage } from '../../features/auth/LoginPage';
import { AboutPage } from '../../features/about/AboutPage';
import { DashboardPage } from '../../features/dashboard/DashboardPage';


export const AppRouter = () => {
  return (
    <Routes>
      {/* Public Routes */}
      <Route path="/login" element={<LoginPage />} />
      <Route path="/about" element={<AboutPage />} />
      
      {/* Protected Routes */}
      <Route
        path="/dashboard"
        element={
          <ProtectedRoute>
            <DashboardPage />
          </ProtectedRoute>
        }
      />
      
      <Route
        path="/telemetry"
        element={
          <ProtectedRoute>
            <div>Telemetry Page - Coming Soon</div>
          </ProtectedRoute>
        }
      />
      
      <Route
        path="/alerts"
        element={
          <ProtectedRoute>
            <div>Alerts Page - Coming Soon</div>
          </ProtectedRoute>
        }
      />
      
      {/* Default redirect */}
      <Route path="/" element={<Navigate to="/dashboard" replace />} />
    </Routes>
  );
};