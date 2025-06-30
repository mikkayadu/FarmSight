// DashboardHome.jsx
import React, { useEffect, useState } from "react";
import "../styles/DashboardHome.css";
import Footer from "../components/Footer.jsx";

import NDVIChart from "../components/NDVICharts";
import FieldMap from "../components/FieldMap";
import NDVILegend from "../components/NDVILegend";
import SoilDroughtIndex from "../components/SoilDroughtIndex";
import AddFieldModal from "../components/AddFieldModal";

const BASE      = import.meta.env.VITE_API_BASE || "http://localhost:7005";
const token     = localStorage.getItem("token")     || "";    // TODO get real JWT
const farmerId  = localStorage.getItem("farmerId")  || "";    // TODO set after login

const DashboardHome = () => {
  /*───────── STATE ─────────*/
  const [fields, setFields]   = useState([]);
  const [loading, setLoading] = useState(true);
  const [showModal, setShowModal] = useState(false);

  /*───────── FETCH FIELDS ─────────*/
  const fetchFields = async () => {
    if (!token || !farmerId) {
      // fallback dummy rows if not logged in / backend offline
      setFields([
        {
          id: 1, name: "F.Name1", location: "Ashimoto",
          coords: "30.2887°N, 30.5536°E",
          areaHa: 46.2, sowingDate: "2025-06-06",
          ndvi: 0.54, change: 0.08,
        },
        {
          id: 2, name: "F.Name2", location: "Ashanti",
          coords: "23.0874°N, 23.5820°E",
          areaHa: 20.6, sowingDate: "2025-06-10",
          ndvi: 0.61, change: -0.06,
        },
      ]);
      setLoading(false);
      return;
    }

    try {
      const res  = await fetch(`${BASE}/api/Field/farmer/${farmerId}`, {
        headers: { Authorization: `Bearer ${token}` },
      });
      if (!res.ok) throw new Error("Fetch failed");
      const json = await res.json();
      setFields(json);
    } catch (err) {
      console.error("Field fetch error:", err);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => { fetchFields(); }, []);

  /*───────── RENDER ─────────*/
  return (
    <>
      <div className="dashboard-wrapper">
        <div className="dashboard-header">
          <h2>Welcome Back, Farmer 👩🏽‍🌾</h2>
          <p>Your farm insights are ready.</p>
        </div>

        <div className="filter-bar">
          <select><option>Index: NDVI</option></select>
          <select><option>Group</option></select>
          <select><option>Crop</option></select>
          <input type="date" />
          <button className="clear-btn">Clear</button>
          <button className="new-field-btn" onClick={() => setShowModal(true)}>
            + New Field
          </button>
        </div>

        {/* FIELD TABLE */}
        <div className="field-table-section">
          <h3>Your Fields</h3>
          {loading ? (
            <p>Loading fields…</p>
          ) : (
            <table>
              <thead>
                <tr>
                  <th>Field</th><th>Location</th><th>Coordinates</th>
                  <th>Area (ha)</th><th>Sowing Date</th><th>NDVI</th><th>Change</th>
                </tr>
              </thead>
              <tbody>
                {fields.map((f) => (
                  <tr key={f.id}>
                    <td>{f.name}</td>
                    <td>{f.location}</td>
                    <td>{f.coords}</td>
                    <td>{f.areaHa}</td>
                    <td>{new Date(f.sowingDate).toLocaleDateString()}</td>
                    <td>{f.ndvi}</td>
                    <td className={f.change >= 0 ? "positive" : "negative"}>
                      {f.change >= 0 ? "+" : ""}{f.change}
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          )}
        </div>

        <div className="chart-section"><NDVIChart /></div>
        <div className="map-wrapper"><FieldMap /></div>
        <div className="ndvi-legend"><NDVILegend /></div>
        <div className="soil-drought"><SoilDroughtIndex /></div>
      </div>

      {/* NEW FIELD MODAL */}
      <AddFieldModal
        open={showModal}
        onClose={() => setShowModal(false)}
        refreshFields={fetchFields}
        farmerId={farmerId}
        token={token}
      />
    <Footer/>
    </>
  );
};

export default DashboardHome;


































// import React from "react";
// import "../styles/DashboardHome.css";
// import NDVIChart from "../components/NDVICharts.jsx";
// import FieldMap from "../components/FieldMap";
// import NDVILegend from "../components/NDVILegend";
// import SoilDroughtIndex from "../components/SoilDroughtIndex";
// import Navbar from "../components/Navbar.jsx";
// import Footer from "../components/Footer.jsx";
//
// const DashboardHome = () => {
//   return (
//      <>
//       {/*<Navbar/>*/}
//       <div className="dashboard-wrapper">
//         <div className="dashboard-header">
//           <h2>Welcome Back, Farmer Nana Yaa 👩🏽‍🌾</h2>
//           <p>Your farm insights are ready.</p>
//         </div>
//
//         <div className="filter-bar">
//           <select>
//             <option>Index: NDVI</option>
//           </select>
//           <select>
//             <option>Group</option>
//           </select>
//           <select>
//             <option>Crop</option>
//           </select>
//           <input type="date"/>
//           <button className="clear-btn">Clear</button>
//           <button className="new-field-btn">+ New Field</button>
//         </div>
//
//         <div className="field-table-section">
//           <h3>Your Fields</h3>
//           <table>
//             <thead>
//             <tr>
//               <th>Field</th>
//               <th>Location</th>
//               <th>Coordinates</th>
//               <th>Area (ha)</th>
//               <th>Sowing Date</th>
//               <th>NDVI</th>
//               <th>Change</th>
//             </tr>
//             </thead>
//             <tbody>
//             <tr>
//               <td>F.Name1</td>
//               <td>Ashimoto</td>
//               <td>30.2887°N, 30.5536°E</td>
//               <td>46.2</td>
//               <td>06 June 2025</td>
//               <td>0.54</td>
//               <td className="positive">+0.08</td>
//             </tr>
//             <tr>
//               <td>F.Name2</td>
//               <td>Ashanti</td>
//               <td>23.0874°N, 23.5820°E</td>
//               <td>20.6</td>
//               <td>10 June 2025</td>
//               <td>0.61</td>
//               <td className="negative">-0.06</td>
//             </tr>
//             <tr>
//               <td>F.Name3</td>
//               <td>Zango</td>
//               <td>23.0874°N, 23.5820°E</td>
//               <td>19.5</td>
//               <td>13 June 2020</td>
//               <td>0.71</td>
//               <td className="negative">-0.01</td>
//             </tr>
//             </tbody>
//           </table>
//         </div>
//
//         <div className="chart-section">
//           <NDVIChart/>
//         </div>
//         <div className="map-wrapper">
//           <FieldMap/>
//         </div>
//         <div className="ndvi-legend">
//           <NDVILegend/>
//         </div>
//
//         <div className="soil-drought">
//           <SoilDroughtIndex/>
//         </div>
//       </div>
//      <Footer/>
//     </>
//   );
// };
//
// export default DashboardHome;
