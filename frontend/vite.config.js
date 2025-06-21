import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
// import tailwindcss from '@tailwindcss/vite'

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  optimizeDeps: {
    include: [
      'react-chartjs-2',
      'chart.js',
      'react-leaflet',
      'leaflet'
    ]
  },
  build: {
    commonjsOptions: {
      include: [/node_modules/],
    },
  },
});
