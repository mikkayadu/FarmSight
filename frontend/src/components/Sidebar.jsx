function Sidebar() {
  return (
    <aside className="w-64 bg-white p-6 border-r">
      <h2 className="text-xl font-semibold mb-6">Filters</h2>
      <ul className="space-y-4 text-gray-700">
        <li>📍 <span className="font-medium">Region</span></li>
        <li>🌿 <span className="font-medium">Variable</span></li>
        <li>📅 <span className="font-medium">Date Range</span></li>
        <li>📤 <span className="font-medium">Download Report</span></li>
      </ul>
    </aside>
  );
}

export default Sidebar;
