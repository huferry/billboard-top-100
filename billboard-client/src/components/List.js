import React, { useEffect, useState } from 'react'
import './List.css'
import axios from 'axios'
import { Table } from 'react-bootstrap'

const List = ({date}) => {

    const year = date?.getFullYear()
    const month = date?.getMonth() + 1
    const day = date?.getDate()

    const [ list, setList ] = useState([])

    const getMoveClass = (item) => {
        if (item.move === null || item.move === undefined) return 'new'
        if (item.move === 0) return 'stay'
        return item.move > 0 ? 'up' : 'down'
    }

    useEffect(() => {
        if (!date) return
        
        axios.get(`${process.env.REACT_APP_API}/SongHit?year=${year}&month=${month}&day=${day}`)
             .then(res => {
                    const list = res.data
                        .sort((a,b) => a.rank - b.rank)
                        .map(item => {
                            item.move = item.lastWeekRank === 0 ? null : item.lastWeekRank - item.rank
                            return item
                        })
                    setList(list)
             })
             .catch(_ => {
                 setList([])
             })
    }, [date])

    return (
        <Table striped bordered hover>
            <thead>
                <tr>
                    <th>#</th>
                    <th>Song</th>
                    <th>Artist</th>
                    <th>Move</th>
                </tr>
            </thead>
            <tbody>
            {
                list.map(item => {
                    return (
                        <tr key={item.id}>
                            <td>{item.rank}</td>
                            <td>{item.title}</td>
                            <td>{item.artist}</td>
                            <td className={getMoveClass(item)}>{Math.abs(item.move)}</td>
                        </tr>
                    )
                })
            }
            </tbody>
        </Table>
    )
}

export default List