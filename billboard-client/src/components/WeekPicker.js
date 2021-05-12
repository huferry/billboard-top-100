import React, { useEffect, useState } from 'react'
import axios from 'axios'
import { Dropdown } from 'react-bootstrap'
import moment from 'moment'

const unique = array => {
    const result = []
    array.forEach(item => {
        if (!result.some(x => x === item)) result.push(item)
    })
    return result
}

const WeekPicker = ({ onChanged }) => {

    const [years, setYears] = useState([])
    const [year, setYear] = useState()
    const [week, setWeek] = useState(1)

    useEffect(() => {
        if (years.length > 0) return

        axios.get(`${process.env.REACT_APP_API}/Week`)
            .then(res => {
                const dates = res.data.map(d => new Date(d))
                const years = unique(dates.map(d => d.getFullYear())).sort()
                setYears(years)
            })
    })

    useEffect( () => {
        if (week && year && onChanged) {
            const date = moment().year(year).isoWeek(week).toDate()
            onChanged(date)
        }
    }, [week, year])

    const weeks = [...Array(52).keys()].map(w => w+1)

    return (
        <div>
            <Dropdown>
                <Dropdown.Toggle variant="success" id="dropdown-basic">
                    { year ?? 'Year' }
                </Dropdown.Toggle>

                <Dropdown.Menu>
                    {
                        years.map(y => {
                            return (
                                <Dropdown.Item 
                                    key={y}
                                    active={year === y}
                                    onSelect={() => setYear(y)}>
                                    {y}
                                </Dropdown.Item>
                            )
                        })
                    }
                </Dropdown.Menu>
            </Dropdown>

            <Dropdown>
                <Dropdown.Toggle variant="success" id="dropdown-basic">
                    {week}
                </Dropdown.Toggle>

                <Dropdown.Menu>
                    {
                        weeks.map(w => (
                            <Dropdown.Item 
                                key={w}
                                active={week === w}
                                onSelect={()=>setWeek(w)}>
                                {w}
                            </Dropdown.Item>
                        ))
                    }
                </Dropdown.Menu>
            </Dropdown>

        </div>
    )

}


export default WeekPicker