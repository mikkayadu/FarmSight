import NDVIChart from "./NDVIChart"; // Adjust path if needed

function Dashboard() {
  return (
    <main className="flex-1 p-6 space-y-6 overflow-auto">
      <div className="grid grid-cols-1 md:grid-cols-4 gap-4">
        <div className="bg-white p-4 rounded shadow text-center">NDVI</div>
        <div className="bg-white p-4 rounded shadow text-center">Rainfall</div>
        <div className="bg-white p-4 rounded shadow text-center">Temperature</div>
        <div className="bg-white p-4 rounded shadow text-center">Alerts</div>
      </div>

      {/* Map Placeholder */}
      <div className="bg-white h-64 rounded shadow flex items-center justify-center">
        EO Map Area
      </div>

      {/* Actual Chart Component */}
      <NDVIChart />
    </main>
  );
}

export default Dashboard;