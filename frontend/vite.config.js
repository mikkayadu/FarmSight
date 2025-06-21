import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';
import commonjs from 'vite-plugin-commonjs';
import path from 'path';

export default defineConfig({
  plugins: [react(), commonjs()],
  resolve: {
    alias: {
      'react-leaflet': path.resolve(__dirname, 'node_modules/react-leaflet'),
      'leaflet': path.resolve(__dirname, 'node_modules/leaflet'),
    },
  },
  optimizeDeps: {
    include: ['react-leaflet', 'leaflet'],
  },
  build: {
    commonjsOptions: {
      include: [/node_modules/],
    },
  },
});
