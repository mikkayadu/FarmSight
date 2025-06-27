import React, { useState } from "react";
import "./AddFieldModal.css";

const BASE = import.meta.env.VITE_API_BASE || "http://localhost:7005";

const AddFieldModal = ({ open, onClose, refreshFields, farmerId, token }) => {
  if (!open) return null;

  const [form, setForm] = useState({
    name: "",
    cropType: "Maize",
    lat1: 0, lng1: 0, lat2: 0, lng2: 0,
    lat3: 0, lng3: 0, lat4: 0, lng4: 0,
    areaHa: 0,
    startDate: new Date().toISOString().slice(0, 10),
    status: 0,
  });

  const handleChange = (e) =>
    setForm({ ...form, [e.target.name]: e.target.value });

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await fetch(`${BASE}/api/Field/${farmerId}`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify(form),
      });
      refreshFields(); // re-fetch field list in Dashboard
      onClose();
    } catch (err) {
      console.error("Field creation failed:", err);
    }
  };

  return (
    <div className="modal-backdrop">
      <div className="modal-card">
        <h3>Add New Field</h3>
        <form onSubmit={handleSubmit} className="field-form">
          <label>
            Field Name
            <input name="name" value={form.name} onChange={handleChange} required />
          </label>

          <label>
            Crop Type
            <select name="cropType" value={form.cropType} onChange={handleChange}>
              <option>Maize</option><option>Rice</option><option>Sorghum</option>
            </select>
          </label>

          <label>
            Area (ha)
            <input
              type="number"
              name="areaHa"
              value={form.areaHa}
              onChange={handleChange}
              step="0.1"
              required
            />
          </label>

          <label>
            Planting Date
            <input
              type="date"
              name="startDate"
              value={form.startDate}
              onChange={handleChange}
              required
            />
          </label>

          {/* For demo you can capture just one lat/lng and keep rest 0 */}
          <label>
            Lat&nbsp;1
            <input type="number" name="lat1" value={form.lat1} onChange={handleChange} step="0.0001" />
          </label>
          <label>
            Lng&nbsp;1
            <input type="number" name="lng1" value={form.lng1} onChange={handleChange} step="0.0001" />
          </label>

          {/* Repeat or leave zeros for lat2-4/lng2-4 */}

          <div className="modal-buttons">
            <button type="button" onClick={onClose} className="cancel-btn">Cancel</button>
            <button type="submit" className="save-btn">Save Field</button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default AddFieldModal;
