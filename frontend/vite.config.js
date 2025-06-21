import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';
import commonjs from 'vite-plugin-commonjs';

export default defineConfig({
  plugins: [react(), commonjs()],
  optimizeDeps: {
    include: [
      'react-chartjs-2',
      'chart.js',
      'react-leaflet',
      'leaflet'
    ],
  },
  build: {
    commonjsOptions: {
      include: [/node_modules/],
    },
  },
});
