import { BrowserRouter } from 'react-router-dom';
import { AppRouter } from './core/router/AppRouter';
import { useEffect } from 'react';
import { useAuthStore } from './core/store/useAuthStore';

function App() {
  const { checkAuth } = useAuthStore();

  useEffect(() => {
    checkAuth();
  }, [checkAuth]);

  return (
    <BrowserRouter>
      <AppRouter />
    </BrowserRouter>
  );
}

export default App;