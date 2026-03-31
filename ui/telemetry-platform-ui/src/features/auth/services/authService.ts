import { apiClient } from '../../../core/api/apiClient';

export interface LoginCredentials {
  email: string;
  password: string;
}

export interface AuthResponse {
  access_token: string;
  user: {
    id: string;
    email: string;
    name: string;
    role: string;
  };
}

export const authService = {
  login: async (email: string, password: string): Promise<AuthResponse> => {
    const response = await apiClient.post<AuthResponse>('/auth/login', {
      email,
      password,
    });
    
    // Store token
    if (response.data.access_token) {
      localStorage.setItem('access_token', response.data.access_token);
    }
    
    return response.data;
  },

  logout: async (): Promise<void> => {
    try {
      await apiClient.post('/auth/logout');
    } catch (error) {
      // Ignore errors on logout
    } finally {
      localStorage.removeItem('access_token');
    }
  },

  getCurrentUser: async () => {
    const response = await apiClient.get('/auth/me');
    return response.data;
  },

  refreshToken: async (): Promise<{ access_token: string }> => {
    const response = await apiClient.post('/auth/refresh');
    if (response.data.access_token) {
      localStorage.setItem('access_token', response.data.access_token);
    }
    return response.data;
  },
};